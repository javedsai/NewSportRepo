using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using XF.Material.Forms.UI;

namespace SportDirect.Infrastructure
{
    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            this.On<iOS>().SetUseSafeArea(true);
            MaterialNavigationPage.SetStatusBarColor(this, (Color)App.AppInstance.Resources["AccentColor"]);
            MaterialNavigationPage.SetAppBarColor(this, (Color)App.AppInstance.Resources["StartGradientColor"]);
            //MaterialNavigationPage.SetHasShadow(this, false);
            //MaterialNavigationPage.SetAppBarTitleTextFontSize(this, (double)App.AppInstance.Resources["FontSizeMedium"]);
            //MaterialNavigationPage.SetAppBarTitleTextAlignment(this, TextAlignment.Start);
            //MaterialNavigationPage.SetAppBarColor(this, (Color)App.AppInstance.Resources["PrimaryColor"]);
            //MaterialNavigationPage.SetHasNavigationBar(this, false);
            //this.BackgroundImageSource = ImageSource.FromFile("bg.png");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
