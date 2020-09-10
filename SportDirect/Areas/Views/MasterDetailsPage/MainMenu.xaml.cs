using SportDirect.Areas.Views.TabbedBaar;
using SportDirect.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.Views.MasterDetailsPage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainMenu : MasterDetailPage
    {
        public static MainMenu Current;  
        public MainMenu()
        {
            InitializeComponent();
            BindingContext = App.Locator.MainMenu;
            //var Homepage = new Home();
            //NavigationPage.SetHasNavigationBar(Homepage, false);
            //Detail = new NavigationPage(Homepage);
            //Detail = new NavigationPage(new MainTabbedBar());
            IsPresented = false;
            Current = this;

          

        }
        //back button disible
        protected override bool OnBackButtonPressed()
        {
            base.OnBackButtonPressed();
            App.Current.MainPage.Navigation.PopModalAsync();
            return true;
        }
    }
}