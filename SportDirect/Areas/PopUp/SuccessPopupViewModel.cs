using Acr.UserDialogs;
using SportDirect.Areas.Views.MasterDetailsPage;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.PopUp
{
    public class SuccessPopupViewModel : BasePageViewModel
    {
        public ICommand PaymentCommand => new Command(async (obj) =>
        { 
            UserDialogs.Instance.ShowLoading();            
            await App.Current.MainPage.Navigation.PushModalAsync(new MainMenu());
            await NavigationService.ClosePopupsAsync();
            UserDialogs.Instance.HideLoading();            
        });
    }
}