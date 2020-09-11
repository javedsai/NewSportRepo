using SportDirect.Interfaces;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.Material.Forms.UI;
using Acr.UserDialogs;

namespace SportDirect.Areas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class CheckInternetPage : ContentPage
    {
        public CheckInternetPage()
        {
            InitializeComponent();
            MaterialNavigationPage.SetHasNavigationBar(this, false);


        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage.Navigation.PopModalAsync();
            return true;
        }
        private async void connection_Tapped(object sender, EventArgs e)
        {
            if (CrossConnectivity.Current.IsConnected)
                App.Current.MainPage.Navigation.PopAsync();
            else
                UserDialogs.Instance.ShowLoading();
            await Task.Delay(500);
                UserDialogs.Instance.HideLoading();
        }
    }
}