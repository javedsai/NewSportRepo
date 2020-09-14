using Acr.UserDialogs;
using SportDirect.Areas.Authentication.Views;
using SportDirect.Assets;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace SportDirect.Areas.Views.MasterDetailsPage.ViewModels
{
    public class MainMenuMasterViewModel : BasePageViewModel
    {
        IApiService _apiService;
        private string _facebookLink;
        public string FacebookLink
        {
            get { return _facebookLink; }
            set { _facebookLink = value; RaisePropertyChanged(); }
        }
        private string _instagram;
        public string Instagram
        {
            get { return _instagram; }
            set { _instagram = value; RaisePropertyChanged(); }
        }
        private string _twitter;
        public string Twitter
        {
            get { return _twitter; }
            set { _twitter = value; RaisePropertyChanged(); }
        }
        private string _pinterest;
        public string Pinterest
        {
            get { return _pinterest; }
            set { _pinterest = value; RaisePropertyChanged(); }
        }
        private string _tumblr;
        public string Tumblr
        {
            get { return _tumblr; }
            set { _tumblr = value; RaisePropertyChanged(); }
        }
        public MainMenuMasterViewModel(IApiService apiService)
        {
            _apiService = apiService;
          //  FillUserDetailsAsync();
            FacebookLink = "https://www.facebook.com/";
            Instagram = "https://www.instagram.com/accounts/login/?hl=en";
            Twitter = "https://twitter.com/login";
            Pinterest = "https://www.tumblr.com/login";
            Tumblr = "https://in.pinterest.com/login/";
        }

        public ICommand BarcodeScanCommand => new Command(async (obj) =>
        {
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                TryHarder = true,
            };
            var Scan = new ZXingScannerPage(options);
            await App.Current.MainPage.Navigation.PushModalAsync(Scan);
            Scan.OnScanResult += (Result) =>
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    //await App.Current.MainPage.Navigation.PushModalAsync();
                    //mycode.Text = Result.Text;
                });
            };
        });
        public ICommand OnSaleCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new PromotionPage());
        });
        public ICommand ReferFriendCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ReferAFriend());
        });
        public ICommand SimpleCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new GetQuotePage());
        });
        public ICommand ComplexCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new ComplexPage());
        });
        public ICommand OrderTrackingCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new OrderTracking());
        });
        public ICommand FAQCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new FAQsPage());
        });
        public ICommand Contactusommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new Contactus());
        });
        public ICommand BookInstallationCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new BookInstallation());
        });
        public ICommand LogoutCommand => new Command(async (obj) =>
        {
            try
            {
                bool? result = await ShowConfirmAlert("Are you sure you want to logout?.", "Logout!", "Yes", "No");
                if (result == null || result.Value == false)
                {
                    return;
                }
                else
                {
                    UserDialogs.Instance.ShowLoading();
                    //  await App.Current.MainPage.Navigation.PopToRootAsync(false);
                    //await App.Current.MainPage.Navigation.PushModalAsync(new LoginPage());

                    Customer_Sqlite obj_ne = new Customer_Sqlite();
                    Customer_Add obj_de = new Customer_Add();
                    await App.Database.DeleteCustomer(obj_ne);
                    await App.Database.DeleteNoteAsync(obj_de);
                    await App.Database.DeleteAdd();
                    await App.Database.DeleteCart();
                    await App.Database.DeleteCus();
                    //   Settings.IsWalkthroughCompleted = false;
                    Settings.Customer_Access_Token = "";
                    Settings.Customer_FName = "";
                    Settings.Customer_LName = "";
                    Settings.Customer_Mobile = "";
                    Settings.Customer_Email = "";
                    Settings.Customer_Id = "";
                    Settings.CheckoutId = "";
                    Application.Current.Properties.Clear();
                    UserDialogs.Instance.HideLoading();
                    await App.Container.GetInstance<Services.Interfaces.INavigationService>().InitializeAsync();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Toast(ex.Message);
                UserDialogs.Instance.HideLoading();
            }
        });
        public ICommand SettingCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new SettingPage());
        });

        public ICommand AboutUsCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new AboutUsPage());
        });
        public ICommand TermsCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new TermsPage());
        });
        public ICommand PrivacySecurityCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new PrivacySecurity());
        });
        public ICommand OurPoliciesCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new OurPolicy());
        });
        public ICommand WarningCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new WarningAdvice());
        });
        public ICommand BusinessLocationCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new BusinessLocation());
        });
        public ICommand LiveCustomerServiceCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new LiveCustomerService());
        });
        public Command FacebookCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Browser.OpenAsync(FacebookLink, BrowserLaunchMode.SystemPreferred);
                });
            }
        }
        public Command InstagramCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Browser.OpenAsync(Instagram, BrowserLaunchMode.SystemPreferred);
                });
            }
        }
        public Command TwitterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Browser.OpenAsync(Twitter, BrowserLaunchMode.SystemPreferred);
                });
            }
        }
        public Command PinterestCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Browser.OpenAsync(Pinterest, BrowserLaunchMode.SystemPreferred);
                });
            }
        }
        public Command TumblrCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await Browser.OpenAsync(Tumblr, BrowserLaunchMode.SystemPreferred);
                });
            }
        }


        private string _fname;

        public string Fname
        {
            get { return _fname; }
            set { _fname = value; RaisePropertyChanged(); }
        }

        private string _lname;

        public string Lname
        {
            get { return _lname; }
            set { _lname = value; RaisePropertyChanged(); }
        }


        private string _mobileNo;

        public string MobileNo
        {
            get { return _mobileNo; }
            set { _mobileNo = value; RaisePropertyChanged(); }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(); }
        }
        private string _fullName;
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; RaisePropertyChanged(); }
        }




        public async System.Threading.Tasks.Task FillUserDetailsAsync()
        {
            try
            {
                List<Customer_Sqlite> obj_new = new List<Customer_Sqlite>();
                obj_new = await App.Database.GetCustomer();
                Email = Convert.ToString(obj_new[0].email);
                Fname = Convert.ToString(obj_new[0].firstName);
                Lname = Convert.ToString(obj_new[0].lastName);
                FullName = obj_new[0].firstName + " " + obj_new[0].lastName;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
        }

        //Api To Get UserInformation
        public async Task InitializeData()
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
                            FullName = res.data.customer.firstName + res.data.customer.lastName;
                            Email = res.data.customer.email;
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
    }
}
