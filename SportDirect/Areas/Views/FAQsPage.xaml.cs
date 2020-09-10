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
    public partial class FAQsPage : ContentPage
    {
        public FAQsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.FAQsPage;
        }
    }
}