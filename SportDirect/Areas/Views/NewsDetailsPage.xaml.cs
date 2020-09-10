using SportDirect.Areas.Model;
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
    public partial class NewsDetailsPage : ContentPage
    {
        private NewsModel _newsmdl;

        public NewsDetailsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.NewsDetailsPage;
           
        }

        public NewsDetailsPage(NewsModel newsmdl)
        {
            this._newsmdl = newsmdl;
            InitializeComponent();
            BindingContext = App.Locator.NewsDetailsPage;
            App.Locator.NewsDetailsPage.Init(_newsmdl);
        }
    }
}