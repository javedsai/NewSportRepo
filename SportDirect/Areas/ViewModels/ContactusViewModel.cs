using Acr.UserDialogs;
using SportDirect.Areas.Views.MasterDetailsPage;
using SportDirect.Behaviors;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class ContactusViewModel : BasePageViewModel
    {
        private string _noteDescreptions;
        public string NoteDescreptions
        {
            get { return _noteDescreptions; }
            set { _noteDescreptions = value;RaisePropertyChanged(); }
        }
        private string _noteDescreptions1;
        public string NoteDescreptions1
        {
            get { return _noteDescreptions1; }
            set { _noteDescreptions1 = value;RaisePropertyChanged(); }
        }
        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged(); }
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
        private string _message;
        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(); }
        }
         
        public ContactusViewModel()
        {
            NoteDescreptions = "Our store is entirely online. Our warehouses are located at Ville Saint Laurent, in the Montreal area.A pick-up can be select as oan option if you live close to Motreal.";
            NoteDescreptions1 = "we work hard to provide low shipping fess to our customers by using over 12 differnt shipping carriers";
        }
        public ICommand SubmitCommand => new Command(async (obj) =>
        {
            if (string.IsNullOrEmpty(Name))
            {
                UserDialogs.Instance.Alert("Please enter the name", "Error", "Ok");
            }             
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
            else if (string.IsNullOrEmpty(MobileNumber))
            {
                UserDialogs.Instance.Alert("Please enter the  phone number", "Error", "Ok");
            }
            else if (string.IsNullOrEmpty(Message))
            {
                UserDialogs.Instance.Alert("Please enter the  message", "Error", "Ok");
            }
            else
            {
                UserDialogs.Instance.ShowLoading();
                await App.Current.MainPage.Navigation.PushModalAsync(new MainMenu());
                UserDialogs.Instance.HideLoading();
            }
        });
    }
}