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
    public partial class MyOrderDetailsPage : ContentPage
    {
        private MyOrderModel _myOrderMdl;

        public MyOrderDetailsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.MyOrderDetailsPage;
        }

        public MyOrderDetailsPage(MyOrderModel myOrderMdl)
        {
            InitializeComponent();
            BindingContext = App.Locator.MyOrderDetailsPage;
            this._myOrderMdl = myOrderMdl;
            App.Locator.MyOrderDetailsPage.Init(_myOrderMdl);
        }
    }
}