using Acr.UserDialogs;
using SportDirect.Areas.Authentication.Views;
using SportDirect.Areas.Views;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class SaveAddressPageViewModel : BasePageViewModel
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
        }
        private string _mobileNumber;
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; RaisePropertyChanged(); }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; RaisePropertyChanged(); }
        }
        private string _organization;
        public string Organization
        {
            get { return _organization; }
            set { _organization = value; RaisePropertyChanged(); }
        }
        private string _street;
        public string Street
        {
            get { return _street; }
            set { _street = value; RaisePropertyChanged(); }
        }
        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; RaisePropertyChanged(); }
        }
        private string _pincode;
        public string Pincode
        {
            get { return _pincode; }
            set { _pincode = value; RaisePropertyChanged(); }
        }

        public SaveAddressPageViewModel()
        {
            Name = string.Empty;
            MobileNumber = string.Empty;
            Address = string.Empty;
            Organization = string.Empty;
            Street = string.Empty;
            City = string.Empty;
            Pincode = string.Empty;
        }
        public ICommand SavedCommand => new Command(async (obj) =>
        {
            if (string.IsNullOrEmpty(Name))
                UserDialogs.Instance.Alert("Please enter the name.", "Error", "Ok");
            else if (string.IsNullOrEmpty(MobileNumber))
                UserDialogs.Instance.Alert("Please enter the mobile number.", "Error", "Ok");
            else if (string.IsNullOrEmpty(Address))
                UserDialogs.Instance.Alert("Please enter the address.", "Error", "Ok");
            else if (string.IsNullOrEmpty(Address))
                UserDialogs.Instance.Alert("Please enter the address.", "Error", "Ok");
            else if (string.IsNullOrEmpty(Organization))
                UserDialogs.Instance.Alert("Please enter the organization.", "Error", "Ok");
            else if (string.IsNullOrEmpty(Street))
                UserDialogs.Instance.Alert("Please enter the street.", "Error", "Ok");
            else if (string.IsNullOrEmpty(City))
                UserDialogs.Instance.Alert("Please enter the city.", "Error", "Ok");
            else if (string.IsNullOrEmpty(Pincode))
                UserDialogs.Instance.Alert("Please enter the pincode.", "Error", "Ok");
            else
                await App.Current.MainPage.Navigation.PushModalAsync(new PaymentPage());
        });
    }
}