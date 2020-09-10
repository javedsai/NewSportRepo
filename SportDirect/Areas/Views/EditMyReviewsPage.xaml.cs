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
    public partial class EditMyReviewsPage : ContentPage
    {
        private MyOrderModel _editMyOrderMdl;

        public EditMyReviewsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.EditMyReviewsPage;
        }

        public EditMyReviewsPage(MyOrderModel editMyOrderMdl)
        {
            InitializeComponent();
            BindingContext = App.Locator.EditMyReviewsPage;
            this._editMyOrderMdl = editMyOrderMdl;
            App.Locator.EditMyReviewsPage.Init(_editMyOrderMdl);
        }
    }
}