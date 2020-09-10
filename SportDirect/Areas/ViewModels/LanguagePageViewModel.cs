using Acr.UserDialogs;
using Plugin.Multilingual;
using SportDirect.Areas.Authentication.ViewModels;
using SportDirect.Areas.Authentication.Views;
using SportDirect.Resources;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class LanguagePageViewModel : BasePageViewModel
    {
        private string _checkRedImage = "CheckRed";
        public string CheckRedImage
        {
            get => _checkRedImage;
            set { _checkRedImage = value; RaisePropertyChanged(); }
        }
        private string _uncheckImage = "Uncheck";
        public string UncheckImage
        {
            get => _uncheckImage;
            set { _uncheckImage = value; RaisePropertyChanged(); }
        }

        public LanguagePageViewModel()
        {

        }
        private bool SelectLanguage = false;
        public ICommand EnglishCommand => new Command(async (obj) =>
          {
              //dropdown by list
              //CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains(picker.SelectedItem.ToString()));
              //AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
              CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("en");
              AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
              CheckRedImage = "CheckRed";
              UncheckImage = "Uncheck";
          });
        public ICommand FrenchCommand => new Command((obj) =>
         {
             CrossMultilingual.Current.CurrentCultureInfo = new CultureInfo("fr");
             AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
             UncheckImage = "CheckRed";
             CheckRedImage = "Uncheck";
             UserDialogs.Instance.Alert("selected franch language.", "Error", "Ok");
         });
        public ICommand ContinueCommmand => new Command(async (obj) =>
        {

            //CrossMultilingual.Current.CurrentCultureInfo = CrossMultilingual.Current.NeutralCultureInfoList.ToList().First(element => element.EnglishName.Contains("French"));
            //AppResources.Culture = CrossMultilingual.Current.CurrentCultureInfo;
            UserDialogs.Instance.ShowLoading();
            await App.Current.MainPage.Navigation.PushAsync(new LoginPage());
            UserDialogs.Instance.HideLoading();
            //if (SelectLanguage == true)            
            //    await NavigationService.NavigateToAsync(new LoginPageViewModel());
            //else
            //    UserDialogs.Instance.Alert("Please select the language.", "Error", "Ok");
        });
    }
}