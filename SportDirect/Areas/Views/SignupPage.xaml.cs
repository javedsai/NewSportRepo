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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.SignupPage;
        }        
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            picker.Focus();
        }
    }
}