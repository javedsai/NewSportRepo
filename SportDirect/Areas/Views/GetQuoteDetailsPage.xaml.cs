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
    public partial class GetQuoteDetailsPage : ContentPage
    {
        public GetQuoteDetailsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.GetQuoteDetailsPage;
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            ShoppingPicker.Focus();
        }

        private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
        {
            InstallationPicker.Focus();
        }
    }
}