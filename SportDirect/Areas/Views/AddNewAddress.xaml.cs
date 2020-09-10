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
    public partial class AddNewAddress : ContentPage
    {
        public AddNewAddress()
        {
            InitializeComponent();
            BindingContext = App.Locator.AddNewAddress;
            App.Locator.AddNewAddress.Init();
            App.Locator.AddNewAddress.IntitializeErrorVisible();
        }
        public AddNewAddress(EditSaveAddressModel editSaveAddressModel)
        {
            InitializeComponent();
            BindingContext = App.Locator.AddNewAddress;
            App.Locator.AddNewAddress.Init(editSaveAddressModel);

        }


    }
}