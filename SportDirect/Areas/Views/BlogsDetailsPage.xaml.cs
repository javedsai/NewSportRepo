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
    public partial class BlogsDetailsPage : ContentPage
    {
        private BlogsModel _blogsmdl;
        public BlogsDetailsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.BlogsDetailsPage;
        }

        public BlogsDetailsPage(BlogsModel blogsmdl)
        {
            InitializeComponent();
            BindingContext = App.Locator.BlogsDetailsPage;
            _blogsmdl = blogsmdl;
            App.Locator.BlogsDetailsPage.Init(_blogsmdl);
        }
    }
}