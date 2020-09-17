using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WebBrowserPage : ContentPage
    {
        public WebBrowserPage(string url)
        {
            InitializeComponent();
            urlSource.Source = url;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}