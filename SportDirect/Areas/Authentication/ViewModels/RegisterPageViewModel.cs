using Acr.UserDialogs;
using SkiaSharp;
using SportDirect.Areas.Authentication.Views;
using SportDirect.Areas.ViewModels;
using SportDirect.Areas.Views;
using SportDirect.Behaviors;
using SportDirect.Core.Models.Authentication.Response;
using SportDirect.Data.Models.Request;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.Authentication.ViewModels
{
    public class RegisterPageViewModel : BasePageViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set { _firstName = value; RaisePropertyChanged(); }
        }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; RaisePropertyChanged(); }
        }
        private string _organizationName;
        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; RaisePropertyChanged(); }
        }
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(); }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; RaisePropertyChanged(); }
        }
        public RegisterPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            FirstName = string.Empty;
            LastName = string.Empty;
            OrganizationName = string.Empty;
            Email = string.Empty;
            Password = string.Empty;
        }

        private IApiService _apiService;

        public void init()
        {
            clearField();
        }
        public void clearField()
        {
            FirstName = "";
            LastName = "";
            Email = "";
            Password = "";
            OrganizationName = "";
        }
        public ICommand RegisterCommand => new Command(async (obj) =>
        {
            try
            {
                if (string.IsNullOrEmpty(FirstName))
                {
                    UserDialogs.Instance.Alert("Please enter the first name", "Error", "Ok");
                }
                else if (string.IsNullOrEmpty(LastName))
                {
                    UserDialogs.Instance.Alert("Please enter the last name", "Error", "Ok");
                }
                //else if (string.IsNullOrEmpty(OrganizationName))
                //{
                //    UserDialogs.Instance.Alert("Please enter the business/organization name", "Error", "Ok");
                //}
                else if (string.IsNullOrEmpty(Email))
                {
                    UserDialogs.Instance.Alert("Please enter the emailid.", "Error", "Ok");
                    return;
                }
                else if (!Regex.IsMatch(Email, RegexBehavior.emailRegex().ToString()))
                {
                    UserDialogs.Instance.Alert("Please enter the valid emailid.", "Error", "Ok");
                    return;
                }
                else if (string.IsNullOrEmpty(Password))
                {
                    UserDialogs.Instance.Alert("Please enter the Password.", "Error", "Ok");
                    return;
                }
                else if (Password.Length < 8)
                {
                    UserDialogs.Instance.Alert("Password length must have atleast 8 characters !!", "Error", "Ok");
                    return;
                }
                else if (!Regex.IsMatch(Password, RegexBehavior.passwordRegex().ToString()))
                {
                    UserDialogs.Instance.Alert("Password should contain atleast one upper case, one lower case, one numeric value and one special character.");
                    return;
                }
                else
                {
                    UserDialogs.Instance.ShowLoading();
                    CreateCusomerRequest obj_cusrequst = new CreateCusomerRequest();
                    obj_cusrequst.input = new Input();
                    obj_cusrequst.input.firstName = FirstName;
                    obj_cusrequst.input.lastName = LastName;
                    //obj_cusrequst.input.phone = "+87698792397";
                    obj_cusrequst.input.password = Password;
                    obj_cusrequst.input.email = Email;
                    string query = @"mutation customerCreate($input: CustomerCreateInput!) {customerCreate(input: $input) { customer { id } customerUserErrors { code field message } } }";
                    var res = await _apiService.CreateCusmerbyGraphql(query, obj_cusrequst);
                    if (res != null)
                    {
                        if (res.data.customerCreate.customer != null)
                        {
                            UserDialogs.Instance.HideLoading();
                            //  Settings.Customer_Id = Convert.ToString(res.customerCreate.customer.id);
                            var cfg = new ToastConfig("You are successfully registered.")
                            {
                                BackgroundColor = Color.Green
                            };
                            UserDialogs.Instance.Toast(cfg);
                            //await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
                            App.Current.MainPage = new NavigationPage(new LoginPage());
                        }
                        else if (res.data.customerCreate.customerUserErrors.Count > 0)
                        {
                            UserDialogs.Instance.HideLoading();
                            string cs = Convert.ToString(res.data.customerCreate.customerUserErrors[0].message);
                            UserDialogs.Instance.Alert(cs);
                        }
                        else
                        {
                            UserDialogs.Instance.HideLoading();
                            UserDialogs.Instance.Alert("There are some problem");
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                        UserDialogs.Instance.Alert("Server not connected");
                    }
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
        });
        public ICommand SigninCommand => new Command(async (obj) =>
         {
             await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
         });



    }
}