using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportDirect.Areas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Acr.UserDialogs;
using SportDirect.Data.Models.Response;

namespace SportDirect.Areas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FeaturedProductPage : ContentPage
    {
        public FeaturedProductPage(bool IsSearch)
        {
            InitializeComponent();
            lastItem.IsVisible = false;
            if (IsSearch)
            {
                sorting.IsVisible = false;
            }
            else
            {
                sorting.IsVisible = true;
            }
            BindingContext = App.Locator.FeaturedProductPage;
            lastItem.IsVisible = false;
            //MessagingCenter.Subscribe<FeaturedProductPageViewModel,bool>(this, "lastPlace", (sender,args)=>
            //{
            //    lastItem.IsVisible = args;
            //});
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

        void FlowListView_ItemAppearing(System.Object sender, Xamarin.Forms.ItemVisibilityEventArgs e)
        {
         
            if (App.Locator.FeaturedProductPage.IsBusy || App.Locator.FeaturedProductPage.ProductList.edges.Count == 0)
                return;
            //hit bottom!
            var i = (System.Collections.IList)e.Item;
            if (i != null)
            {
                var last = i[i.Count - 1] as CollectionProductListDataEdge;
                if (last != null)
                {
                    if (last == App.Locator.FeaturedProductPage.ProductList.edges[App.Locator.FeaturedProductPage.ProductList.edges.Count - 1])
                    {
                        App.Locator.FeaturedProductPage.ThresoldCommand.Execute(null);
                        lastItem.IsVisible = true;
                    }
                }

            }

        }
    }
}