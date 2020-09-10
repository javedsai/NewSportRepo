using Acr.UserDialogs;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SportDirect.Assets;
using SportDirect.Data.Models.Request;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class AccountSettinPageViewModel : BasePageViewModel
    {
        private IApiService _apiService;
        private ImageSource _profileImageSource = "Profilepic";
        public ImageSource ProfileImageSource
        {
            get => _profileImageSource;
            set
            {
                _profileImageSource = value;
                RaisePropertyChanged();
            }
        }
        private string _profileName;
        public string ProfileName
        {
            get { return _profileName; }
            set { _profileName = value; RaisePropertyChanged(); }
        }
        private string _profileEmail;
        public string ProfileEmail
        {
            get { return _profileEmail; }
            set { _profileEmail = value; RaisePropertyChanged(); }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; RaisePropertyChanged(); }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(); }
        }

        public AccountSettinPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            FillUser();
            //ProfileName = "Jenny Smith";
            //ProfileEmail = "jennysmith@xyz.com";
            //PhoneNumber = "+00-123465789";
            //Password= "*******";
        }

        public async void FillUser()
        {
            List<Customer_Sqlite> obj_new = new List<Customer_Sqlite>();
            obj_new = await App.Database.GetCustomer();
            ProfileName = Convert.ToString(obj_new[0].firstName) + " " + Convert.ToString(obj_new[0].lastName);
            ProfileEmail = Convert.ToString(obj_new[0].email);
            PhoneNumber = obj_new[0].phone;
            Password = "*******";
        }


        public ICommand ProfilePicCommand => new Command(async (obj) =>
        {
            try
            {
                await CrossMedia.Current.Initialize();
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file != null)
                {
                    //imagename = file.Path;
                    ProfileImageSource = ImageSource.FromStream(() =>
                    {
                        var stream = file.GetStream();
                        return stream;
                    });
                }
                else
                {
                    UserDialogs.Instance.Alert("Picking a photo is not supported", "No upload", "Ok");
                    return;
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.ToString(), "Error", "OK");
            }
        });
        public ICommand SaveCommand => new Command(async (obj) =>
         {
             if (string.IsNullOrEmpty(ProfileName))
             {
                 await ShowAlert("Name is mandetory");
                 return;
             }
             if (!ProfileName.Contains(" "))
             {
                 await ShowAlert("Enter first name and last name with space");
                 return;
             }
             if (string.IsNullOrEmpty(PhoneNumber) && PhoneNumber.Length < 5 && PhoneNumber.Length > 15)
             {
                 await ShowAlert("Enter valid phone number");
                 return;
             }

             string queryid_id = @"mutation customerUpdate($customerAccessToken: String!, $customer: CustomerUpdateInput!) {
                                  customerUpdate(customerAccessToken: $customerAccessToken, customer: $customer) {
                                    customer {
                                      id
                                    }
                                    customerAccessToken {
                                      accessToken
                                      expiresAt
                                    }
                                    customerUserErrors {
                                      code
                                      field
                                      message
                                    }
                                  }
                                }";
             CustomerUpdateRequest request = new CustomerUpdateRequest();
             request.customer = new UpdateCustomer();
             request.customerAccessToken = Settings.Customer_Access_Token;
             request.customer.firstName = ProfileName.Split(' ')[0];
             request.customer.lastName = ProfileName.Split(' ')[1];
             request.customer.phone = PhoneNumber;
             try
             {
                 var res1 = await _apiService.CustomerUpdate(queryid_id, request);
                 if (!string.IsNullOrEmpty(res1?.data?.customerUpdate?.customer?.id))
                 {
                     var obj_new = await App.Database.GetCustomer();
                     await App.Database.DeleteCustomer(obj_new[0]);
                     Customer_Sqlite obj_customer = new Customer_Sqlite();
                     obj_customer.firstName = request.customer.firstName;
                     obj_customer.lastName = request.customer.lastName;
                     obj_customer.email = ProfileEmail;
                     obj_customer.customerID = Settings.Customer_Id;
                     obj_customer.Customer_Access_Token = Settings.Customer_Access_Token;
                     obj_customer.createdAt = DateTime.Now.Date;
                     obj_customer.phone = request.customer.phone;
                     await App.Database.SaveCustomerAsync(obj_customer);

                     App.Locator.ProfilePage.ProfileName = ProfileName;
                     App.Locator.ProfilePage.PhoneNumber = PhoneNumber;

                     App.Locator.MainMenuMaster.FullName = ProfileName;
                     await ShowAlert("Profile Updated Successfully");
                     await App.Current.MainPage.Navigation.PopModalAsync();
                 }
                 else if(res1?.data?.customerUpdate?.customerUserErrors.Count > 0)
                 {
                     await ShowAlert(res1?.data?.customerUpdate?.customerUserErrors[0]?.message);
                 }
                 else
                 {
                     await ShowAlert("Profile doesn't Updated Successfully");
                 }
             }
             catch(Exception ex)
             {
                 await ShowAlert("Internal server error");
             }
         });
    }
}