using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportDirect.Service.Interfaces;
using SportDirect.Areas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomersPage : ContentPage
    {
        public CustomersPage(IApiService apiService)
        {
            InitializeComponent();
            BindingContext = App.Locator.CustomersPage;
            App.Locator.CustomersPage.InitilizeData(App.Locator.Home.CategoriesImagesList);
        }
    }
}