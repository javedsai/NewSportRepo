using Acr.UserDialogs;
using SportDirect.Areas.Views;
using SportDirect.Assets;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class ProfilePageViewModel : BasePageViewModel
    {
        private IApiService _apiService;
        private string _profilePic;
        public string ProfilePic
        {
            get { return _profilePic; }
            set { _profilePic = value; RaisePropertyChanged(); }
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

        public ProfilePageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            FillDetails();
            //ProfilePic = "Profilepic";
            //ProfileName = "Jenny Smith";
            //ProfileEmail = "jennysmith@xyz.com";
            //PhoneNumber = "+00-123465789";
        }

        public async void FillDetails()
        {
            UserDialogs.Instance.ShowLoading();

            try
            {
                string queryid_id = "{ customer(customerAccessToken:\"" + Settings.Customer_Access_Token + "\"){ id firstName lastName phone email createdAt } }";
                var res = await _apiService.CustomerInfo(queryid_id);

                if (res.data != null)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(res.data.customer.id)))
                    {
                        ProfileName = res.data.customer.firstName + res.data.customer.lastName;
                        ProfileEmail = res.data.customer.email;
                        PhoneNumber = res.data.customer.phone;
                        Settings.Customer_Email = res.data.customer.email;
                        //App.Locator.ProfilePage.InitializeUserInfo(res.data.customer);
                        //App.Locator.AccountSettinPage.InitializeUserInfo(res.data.customer);
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Please enter the valid emailid and password.", "Error", "Ok");
                    }
                }
                else
                {
                    //UserDialogs.Instance.Alert("Server not connected", "Error", "Ok");
                }
            }
            catch (Exception ex)
            {

                UserDialogs.Instance.Alert(ex.Message.ToString());
            }


            UserDialogs.Instance.HideLoading();

        }
        public Command AccountSettingCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new AccountSettinPage());
                });
            }
        }
        public Command SaveAddressCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new EditSaveAddress());
                });
            }
        }
        public Command MyOrderCommand
        {
            get
            {
                return new Command(async () =>
                {
                    App.Locator.MyOrderPage.GetMyOrderList();
                    await App.Current.MainPage.Navigation.PushModalAsync(new MyOrderPage());
                });
            }
        }
        public Command MyReviewsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new MyReviewsPage());
                });
            }
        }
        public Command MyFavoritsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new MyFavorites());
                });
            }
        }
    }
}