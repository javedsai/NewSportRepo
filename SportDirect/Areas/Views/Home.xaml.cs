using SportDirect.Data.Models.Response;
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
    public partial class Home : ContentPage, IMainView, IRootView
    {
        public Home()
        {
            InitializeComponent();
            BindingContext = App.Locator.Home;
            App.Locator.Home.GetFeaturedProductList();
            App.Locator.Home.GetNewProductList();
            App.Locator.Home.GetCollectionList();
        }

        //protected override void OnAppearing()
        //{
        //    App.Locator.Home.LoadDeshboardList();
        //    base.OnAppearing();
        //}

        protected override bool OnBackButtonPressed()
        {
            return false;
        }
    }
}