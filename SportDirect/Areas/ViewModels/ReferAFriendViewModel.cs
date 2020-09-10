using SportDirect.Areas.Views;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class ReferAFriendViewModel : BasePageViewModel
    {
        public ICommand ContinuePaymentCommand => new Command(async (obj) =>
          {
             await App.Current.MainPage.Navigation.PushModalAsync(new PaymentPage());
          });
    }
}