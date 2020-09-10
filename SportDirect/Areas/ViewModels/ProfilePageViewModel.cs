using Acr.UserDialogs;
using SportDirect.Areas.Views;
using SportDirect.Assets;
using SportDirect.Helpers;
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

        public ProfilePageViewModel()
        {
            FillDetails();
            //ProfilePic = "Profilepic";
            //ProfileName = "Jenny Smith";
            //ProfileEmail = "jennysmith@xyz.com";
            //PhoneNumber = "+00-123465789";
        }

        public async void FillDetails()
        {
            List<Customer_Sqlite> obj_new = new List<Customer_Sqlite>();
            obj_new = await App.Database.GetCustomer();
            ProfilePic = "Profilepic";
            ProfileName = Convert.ToString(obj_new[0].firstName) + " " + Convert.ToString(obj_new[0].lastName);
            ProfileEmail = Convert.ToString(obj_new[0].email);
            // PhoneNumber = Settings.Customer_Mobile)

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