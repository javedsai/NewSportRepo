using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class GetQuoteDetailsPageViewModel :BasePageViewModel
    {        
        private string _address;
        public string Address
        {
            get { return _address; }
            set { _address = value; RaisePropertyChanged(); }
        }

        private string _apartment;
        public string Apartment
        {
            get { return _apartment; }
            set { _apartment = value; RaisePropertyChanged(); }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set { _city = value; RaisePropertyChanged(); }
        }
        private string _province;
        public string Province
        {
            get { return _province; }
            set { _province = value; RaisePropertyChanged(); }
        }
        private string _country;
        public string Country
        {
            get { return _country; }
            set { _country = value; RaisePropertyChanged(); }
        }
        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; RaisePropertyChanged(); }
        } 
        private SignupModel _selectShopping;
        public SignupModel SelectShopping
        {
            get { return _selectShopping; }
            set { _selectShopping = value;RaisePropertyChanged(); }
        }
        private SignupModel _selectInstallation;
        public SignupModel SelectInstallation
        {
            get { return _selectInstallation; }
            set { _selectInstallation = value;RaisePropertyChanged(); }
        }
        private string _po;
        public string Po
        {
            get { return _po; }
            set { _po = value;RaisePropertyChanged(); }
        }
        private string _comment;
        public string Comment
        {
            get { return _comment; }
            set { _comment = value;RaisePropertyChanged(); }
        }
        private ObservableCollection<CartModel> _quoteDetailsList;
        public ObservableCollection<CartModel> QuoteDetailsList
        {
            get { return _quoteDetailsList; }
            set { _quoteDetailsList = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<SignupModel> _shoppingList;
        public ObservableCollection<SignupModel> ShoppingList
        {
            get { return _shoppingList; }
            set { _shoppingList = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<SignupModel> _installationList;
        public ObservableCollection<SignupModel> InstallationList
        {
            get { return _installationList; }
            set { _installationList = value; RaisePropertyChanged(); }
        }
        public GetQuoteDetailsPageViewModel()
        {
            QuoteDetailsList = GetQuoteDetailsList();
            ShoppingList = GetShoppingList();
            InstallationList = GetInstallationList();
            SelectShopping= null;
            SelectInstallation= null;
        }

        public ObservableCollection<CartModel> GetQuoteDetailsList()
        {
            return new ObservableCollection<CartModel>()
            {
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00"},
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00"},
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00"},
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00"},
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00"},
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00"},
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00"},
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00"},
          };
        }
        
        public ObservableCollection<SignupModel> GetShoppingList()
        {
            return new ObservableCollection<SignupModel>()
            {
                new SignupModel{ Name="YES" },
                new SignupModel{ Name="No" }
            };
        }
        public ObservableCollection<SignupModel> GetInstallationList()
        {
            return new ObservableCollection<SignupModel>()
            {
                new SignupModel{ Name="YES" },
                new SignupModel{ Name="No" }
            };
        }
        public ICommand ChangeCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ICommand NextCommand => new Command(async (obj) =>
        {
            if (string.IsNullOrEmpty(Address))
            {
                UserDialogs.Instance.Alert("Please enter the address", "Error", "Ok");
            } 
           else if (string.IsNullOrEmpty(Apartment))
            {
                UserDialogs.Instance.Alert("Please enter the  apartment, suit", "Error", "Ok");
            } 
           else if (string.IsNullOrEmpty(City))
            {
                UserDialogs.Instance.Alert("Please enter the  city", "Error", "Ok");
            }
           else if (string.IsNullOrEmpty(Province))
            {
                UserDialogs.Instance.Alert("Please enter the  province", "Error", "Ok");
            }
           else if (string.IsNullOrEmpty(Country))
            {
                UserDialogs.Instance.Alert("Please enter the  country", "Error", "Ok");
            }
           else if (string.IsNullOrEmpty(PostalCode))
            {
                UserDialogs.Instance.Alert("Please enter the  Postal code", "Error", "Ok");
            }
           //else if (SelectShopping == null)
            //{
                //UserDialogs.Instance.Alert("Please select shopping", "Error", "Ok");
            //}
           //else if (SelectInstallation == null)
            //{
                //UserDialogs.Instance.Alert("Please select installation", "Error", "Ok");
            //}
            else if (string.IsNullOrEmpty(Po))
            {
                UserDialogs.Instance.Alert("Please enter the  po", "Error", "Ok");
            }
            else if (string.IsNullOrEmpty(Comment))
            {
                UserDialogs.Instance.Alert("Please enter the  comment", "Error", "Ok");
            }
            else
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new PaymentPage());
            }
        });
    }
} 