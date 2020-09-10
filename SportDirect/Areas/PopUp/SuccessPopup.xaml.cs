using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.PopUp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SuccessPopup : PopupPage
    {
        public SuccessPopup()
        {
            InitializeComponent();
            BindingContext = App.Locator.SuccessPopup;
        }
    }
}