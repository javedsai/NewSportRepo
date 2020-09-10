using SportDirect.Interfaces;
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
    public partial class LanguagePage : ContentPage,IMainView,IRootView
    {
        public LanguagePage()
        {
            InitializeComponent();
            BindingContext = App.Locator.LanguagePage;
        }
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage.Navigation.PopModalAsync();
            return true;
        }
    }
}