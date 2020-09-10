using Acr.UserDialogs;
using SportDirect.Areas.Authentication.Views;
using SportDirect.Areas.ViewModels;
using SportDirect.Areas.Views;
using SportDirect.Areas.Views.MasterDetailsPage;
using SportDirect.Areas.Views.MasterDetailsPage.ViewModels;
using SportDirect.Assets;
using SportDirect.Behaviors;
using SportDirect.Data.Models.Request;
using SportDirect.Data.Models.Response;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportDirect.Areas.Authentication.ViewModels
{
    public class LoginPageViewModel : BasePageViewModel
    {
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

        private string _facebookLink;
        public string FacebookLink
        {
            get { return _facebookLink; }
            set { _facebookLink = value; RaisePropertyChanged(); }
        }
        private string _googleLink;
        public string GoogleLink
        {
            get { return _googleLink; }
            set { _googleLink = value; RaisePropertyChanged(); }
        }
        public LoginPageViewModel(IApiService apiService)
        {
            ImageVisible = "hide.png";
            Ispwd = true;
            _apiService = apiService;
            FacebookLink = "https://www.facebook.com";
            GoogleLink = "https://www.google.com";
            Email = "";
            Password = "";

        }

        public void init()
        {
            Email = "";
            Password = "";
        }

        public ICommand ForgotPassword => new Command((obj) =>
        {
            // await App.Current.MainPage.Navigation.PushAsync(new CheckInternetPage());
            UserDialogs.Instance.Alert("In progress");
        });
        private IApiService _apiService;
        public ICommand SigninCommand => new Command(async (obj) =>
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                if (string.IsNullOrEmpty(Email))
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert("Email can not be blank.");
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert("Password can not be blank.");
                    return;
                }
                string queryid_id = @"mutation customerAccessTokenCreate($input: CustomerAccessTokenCreateInput!) {
                    customerAccessTokenCreate(input: $input) {
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
                LoginRequest loginRequest = new LoginRequest();
                loginRequest.input = new Input_Log();
                loginRequest.input.email = Email;
                loginRequest.input.password = Password;

                var res = await _apiService.CustomerLogin(queryid_id, loginRequest);

                if (res.data != null)
                {
                    if (!string.IsNullOrEmpty(Convert.ToString(res.data.customerAccessTokenCreate.customerAccessToken)))
                    {

                        //Xamarin.Forms.Device.BeginInvokeOnMainThread(async () =>
                        //{
                        Settings.Customer_Access_Token = Convert.ToString(res.data.customerAccessTokenCreate.customerAccessToken.accessToken);
                        string accestoken = Convert.ToString(res.data.customerAccessTokenCreate.customerAccessToken.accessToken);
                        char quote = '"';
                        string modifiedString = quote + accestoken + quote;
                        string query = "{ customer(customerAccessToken:" + modifiedString + "){ id firstName lastName  email createdAt  phone addresses(first: 9){ edges{  node{id firstName lastName address1 address2 city company country zip } } } } }";
                        var res1 = await _apiService.GetCustomer(query);
                        if (res1 != null)
                        {

                            Settings.Customer_Id = Convert.ToString(res1.data.customer.id);
                            Customer_Sqlite obj_customer = new Customer_Sqlite();
                            obj_customer.firstName = Convert.ToString(res1.data.customer.firstName);
                            obj_customer.lastName = Convert.ToString(res1.data.customer.lastName);
                            obj_customer.email = Convert.ToString(res1.data.customer.email);
                            obj_customer.customerID = Convert.ToString(res1.data.customer.id);
                            obj_customer.Customer_Access_Token = Convert.ToString(res.data.customerAccessTokenCreate.customerAccessToken.accessToken);
                            obj_customer.createdAt = res1.data.customer.createdAt;
                            obj_customer.phone = res1.data.customer.phone;
                            await App.Database.SaveCustomerAsync(obj_customer);
                            //foreach (var item in res1.data.customer.addresses.edges)
                            //{
                            //    Customer_Add customer_Sql = new Customer_Add();
                            //    customer_Sql.firstName = Convert.ToString(item.node.firstName);
                            //    customer_Sql.lastName = Convert.ToString(item.node.lastName);
                            //    customer_Sql.address1 = Convert.ToString(item.node.address1);
                            //    customer_Sql.address2 = Convert.ToString(item.node.address2);
                            //    customer_Sql.company = Convert.ToString(item.node.company);
                            //    customer_Sql.country = Convert.ToString(item.node.country);
                            //    customer_Sql.id = Convert.ToString(item.node.id);
                            //    customer_Sql.zip = item.node.zip;
                            //    await App.Database.SaveNoteAsync(customer_Sql);
                            //}
                        }
                        else
                        {
                            Settings.Customer_Id = "";
                            Settings.Customer_FName = "";
                            Settings.Customer_LName = "";
                            Settings.Customer_Email = "";
                            Settings.CheckoutId = "";
                        }

                        //       await App.Current.MainPage.Navigation.PushModalAsync(new MainMenu());
                        Settings.IsWalkthroughCompleted = true;

                        //});
                        App.Current.MainPage = new NavigationPage(new MainMenu());

                    }
                    else if (res.data.customerAccessTokenCreate.customerUserErrors.Count > 0)
                    {
                        string msg = Convert.ToString(res.data.customerAccessTokenCreate.customerUserErrors[0].message);
                        UserDialogs.Instance.Alert("Please enter the valid emailid and password.", "Error", "Ok");
                    }
                    else
                    {
                        UserDialogs.Instance.Alert("Please enter the valid emailid and password.", "Error", "Ok");
                    }
                }
                else
                {
                    UserDialogs.Instance.Alert("Server not connected", "Error", "Ok");
                }
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
        });


        public ICommand NewaccountCommand => new Command(async (obj) =>
         {
             await App.Current.MainPage.Navigation.PushAsync(new RegisterPage());
         });

        //public Command FacebookCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            await Browser.OpenAsync(FacebookLink, BrowserLaunchMode.SystemPreferred);
        //        });
        //    }
        //}
        //public Command GoogleCommand
        //{
        //    get
        //    {
        //        return new Command(async () =>
        //        {
        //            await Browser.OpenAsync(GoogleLink, BrowserLaunchMode.SystemPreferred);
        //        });
        //    }
        //}


        public ICommand password_showCommand => new Command(password_showHide);

        private bool _Ispwd;

        public bool Ispwd
        {
            get { return _Ispwd; }
            set { _Ispwd = value; RaisePropertyChanged(); }
        }

        private string _imageVisible;

        public string ImageVisible
        {
            get { return _imageVisible; }
            set { _imageVisible = value; RaisePropertyChanged(); }
        }

        private void password_showHide(object obj)
        {
            if (Ispwd)
            {
                Ispwd = false;
                ImageVisible = "iconfinder_eye_226579";
            }
            else
            {
                Ispwd = true;
                ImageVisible = "hide.svg";
            }
        }
    }
}