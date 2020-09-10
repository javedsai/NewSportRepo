using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Behaviors;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class GetQuotePageViewModel : BasePageViewModel
    {
		private ObservableCollection<CartModel> _quoteList;
		public ObservableCollection<CartModel> QuoteList
		{
			get { return _quoteList; }
			set { _quoteList = value; RaisePropertyChanged(); }
		}
  
		public GetQuotePageViewModel()
		{
			QuoteList = GetQuoteList();
            FirstName = string.Empty;
            LastName = string.Empty;
            OrganizationName = string.Empty;
            Email = string.Empty;
            MobileNumber = string.Empty;
        }

		public ObservableCollection<CartModel> GetQuoteList()
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
        
        private string _email;
        public string Email
        {
            get { return _email; }
            set { _email = value; RaisePropertyChanged(); }
        }
        private string _mobileNumber;
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; RaisePropertyChanged(); }
        }
        private string _organizationName;
        public string OrganizationName
        {
            get { return _organizationName; }
            set { _organizationName = value; RaisePropertyChanged(); }
        }
        public ICommand ChangeCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ICommand NextCommand => new Command(async (obj) =>
        {
            if (string.IsNullOrEmpty(FirstName))
            {
                UserDialogs.Instance.Alert("Please enter the first name", "Error", "Ok");
            }
            else if (string.IsNullOrEmpty(LastName))
            {
                UserDialogs.Instance.Alert("Please enter the last name", "Error", "Ok");
            }
           
            else if (string.IsNullOrEmpty(Email))
            {
                UserDialogs.Instance.Alert("Please enter the email id.", "Error", "Ok");
                return;
            }
            else if (!Regex.IsMatch(Email, RegexBehavior.emailRegex().ToString()))
            {
                UserDialogs.Instance.Alert("Please enter the valid emailid.", "Error", "Ok");
                return;
            }
            else if (string.IsNullOrEmpty(MobileNumber))
            {
                UserDialogs.Instance.Alert("Please enter the mobile number.", "Error", "Ok");
                return;
            }
            else if (string.IsNullOrEmpty(OrganizationName))
            {
                UserDialogs.Instance.Alert("Please enter the Company/institution name", "Error", "Ok");
            }
            else
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new GetQuoteDetailsPage());
            }
        });
    }
}