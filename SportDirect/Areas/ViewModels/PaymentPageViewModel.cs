using Acr.UserDialogs;
using SportDirect.Areas.PopUp;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class PaymentPageViewModel : BasePageViewModel
    { 
        private string _checkImage = "Uncheck";
        public string CheckImage
        {
            get => _checkImage;
            set { _checkImage = value; RaisePropertyChanged(); }
        }
        private string _uncheckImage1= "Uncheck";
        public string UncheckImage1
        {
            get => _uncheckImage1; 
            set { _uncheckImage1 = value;RaisePropertyChanged(); }
        }
        private string _uncheckImage2= "Uncheck";
        public string UncheckImage2
        {
            get => _uncheckImage2; 
            set { _uncheckImage2 = value;RaisePropertyChanged(); }
        }
        private string _uncheckImage3 = "Uncheck";
        public string UncheckImage3
        {
            get => _uncheckImage3;
            set { _uncheckImage3 = value; RaisePropertyChanged(); }
        }
        private string _saveCheckImage= "CheckGreen";
        public string SaveCheckImage
        {
            get => _saveCheckImage; 
            set { _saveCheckImage = value;RaisePropertyChanged(); }
        }
        private string _creditCardImage = "Uncheck";
        public string CreditCardImage
        {
            get => _creditCardImage; 
            set { _creditCardImage = value;RaisePropertyChanged(); }
        }
        private string _purchaseOrderImage = "Uncheck";
        public string PurchaseOrderImage
        {
            get => _purchaseOrderImage; 
            set { _purchaseOrderImage = value;RaisePropertyChanged(); }
        }
        private string _checkImag = "Uncheck";
        public string CheckImg
        {
            get => _checkImag; 
            set { _checkImag = value;RaisePropertyChanged(); }
        }
        private string _paypalExpressCheckImage = "Uncheck";
        public string PaypalExpressCheckImage
        {
            get => _paypalExpressCheckImage; 
            set { _paypalExpressCheckImage = value;RaisePropertyChanged(); }
        }
         private string _interacImage = "Uncheck";
        public string InteracImage
        {
            get => _interacImage; 
            set { _interacImage = value;RaisePropertyChanged(); }
        }

        private string _cardNumber; 
        public string CardNumber
        {
            get => _cardNumber;  
            set { _cardNumber = value; RaisePropertyChanged(); }
        }
        private string _cardName;
        public string CardName
        {
            get => _cardName; 
            set { _cardName = value;RaisePropertyChanged(); }
        }
        private string _expiry;
        public string Expiry
        {
            get { return _expiry; }
            set { _expiry = value;RaisePropertyChanged(); }
        }  
        private DateTime _fromMiminumDate;
        public DateTime FromMiminumDate
        {
            get { return _fromMiminumDate; }
            set { _fromMiminumDate = value;RaisePropertyChanged(); }
        }
        private string _cvv;
        public string cvv
        {
            get => _cvv; 
            set { _cvv = value;RaisePropertyChanged(); }
        }

        public PaymentPageViewModel()
        {
            FromMiminumDate = DateTime.Now;
            Expiry = null;
        }
        public ICommand AmexCommand => new Command(async (obj) =>
        {
            UncheckImage1 = "CheckGreen";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "Uncheck";
            CheckImage = "Uncheck";
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "Uncheck";
            //CheckImage = "Uncheck";
            PaypalExpressCheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand ApplepayCommand => new Command(async (obj) =>
        {
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "CheckGreen";
            UncheckImage3 = "Uncheck";
            CheckImage = "Uncheck";
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "Uncheck";
            //CheckImage = "Uncheck";
            PaypalExpressCheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand GPayCommand => new Command(async (obj) =>
        {            
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "CheckGreen";
            CheckImage = "Uncheck";
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "Uncheck";
           // CheckImage = "Uncheck";
            PaypalExpressCheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand MasterCardCommand => new Command(async (obj) =>
        {            
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "Uncheck";
            CheckImage = "CheckGreen";
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "Uncheck"; 
            PaypalExpressCheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand CreditCardCommand => new Command(async (obj) =>
        {
            CreditCardImage = "CheckGreen";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "Uncheck";  
            PaypalExpressCheckImage = "Uncheck";
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "Uncheck";
            CheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand PurchaseOrderCommand => new Command(async (obj) =>
        {
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "CheckGreen";
            CheckImg = "Uncheck"; 
            PaypalExpressCheckImage = "Uncheck";
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "Uncheck";
            CheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand CheckCommand => new Command(async (obj) =>
        {
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "CheckGreen"; 
            PaypalExpressCheckImage = "Uncheck";
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "Uncheck";
            CheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand PaypalExpressCheckoutCommand => new Command(async (obj) =>
        {
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "Uncheck"; 
            PaypalExpressCheckImage = "CheckGreen";
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "Uncheck";
            CheckImage = "Uncheck";
            InteracImage = "Uncheck";
        });
        public ICommand InteracCommand => new Command(async (obj) =>
        {
            CreditCardImage = "Uncheck";
            PurchaseOrderImage = "Uncheck";
            CheckImg = "Uncheck"; 
            PaypalExpressCheckImage = "Uncheck";
            UncheckImage1 = "Uncheck";
            UncheckImage2 = "Uncheck";
            UncheckImage3 = "Uncheck";
            CheckImage = "Uncheck";
            InteracImage = "CheckGreen";
        });
        private bool Check = false;
        public ICommand SaveAndUnsaveCardCommand => new Command(async (obj) =>
        {
        if (Check == false)
            {
                SaveCheckImage = "Uncheck";
                Check = true;
            }
            else
            {
                SaveCheckImage = "CheckGreen";
                Check = false;
            }            
        });
        public ICommand PaymentCommand => new Command(async (obj) =>
        { 
            if (string.IsNullOrEmpty(CardNumber))
            {
                UserDialogs.Instance.Alert("Please enter the card number.", "Error","Ok"); 
            } 
            else if (string.IsNullOrEmpty(CardName))
            {
                UserDialogs.Instance.Alert("Please enter the card name.", "Error","Ok"); 
            } 
            else if (string.IsNullOrEmpty(Expiry))
            {
                UserDialogs.Instance.Alert("Please enter the expiry date.", "Error","Ok"); 
            } 
            else if (string.IsNullOrEmpty(cvv))
            {
                UserDialogs.Instance.Alert("Please enter the cvv.", "Error","Ok"); 
            }
            else
            {
                await Rg.Plugins.Popup.Services.PopupNavigation.Instance.PushAsync(new SuccessPopup());
                CardNumber = string.Empty;
                CardName = string.Empty;
                Expiry = string.Empty;
                cvv = string.Empty;
            }
        });
    }
}