using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

namespace SportDirect.Areas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeaturedProductPage : ContentPage
    {
        public FeaturedProductPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.FeaturedProductPage;
        }

        void CollectionView_Scrolled(System.Object sender, Xamarin.Forms.ItemsViewScrolledEventArgs e)
        {
            var data = e.LastVisibleItemIndex;
            //if (data == fet[0])
            //{
            //    //Debug.WriteLine("First Item has been hit!");
            //}
            if (data ==App.Locator.FeaturedProductPage.ProductList.edges.Count-1)
            {
                App.Locator.FeaturedProductPage.ThresoldCommand.Execute(null);
                //Debug.WriteLine("Last Item has been hit!");
            }
        }
    }
}