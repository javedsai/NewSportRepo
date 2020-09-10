using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SportDirect.Areas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailsPage : ContentPage
    {
        public ProductDetailsPage()
        {
            InitializeComponent();
            BindingContext = App.Locator.ProductDetailsPage;
           
        }
        //private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var item = (sender as Frame).BindingContext as ProductDetailModel;
        //        if (!item.IsSelected)
        //        {
        //            item.ColorSelected = Color.FromHex("#1B8DBA");
        //            item.IsSelected = true;
        //             App.Locator.ProductDetailsPage.PrevColor.ColorSelected = Color.Transparent;
        //            App.Locator.ProductDetailsPage.PrevColor.IsSelected = false;
        //            App.Locator.ProductDetailsPage.PrevColor = item;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        UserDialogs.Instance.Alert(ex.Message);
        //    }
        //    //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        //}

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            try
            {
                var cl = ((sender as Frame).Parent as CollectionView).ItemsSource as IList<Data.Models.Common.Data>;
                foreach (var it in cl)
                {
                    it.BorderCol = "White";
                    it.IsSelected = false;
                }
                var item = (sender as Frame).BindingContext as Data.Models.Common.Data;
                item.BorderCol = "Black";
                item.IsSelected = true;
                App.Locator.ProductDetailsPage.CheckAvailibilityCmd.Execute(item);
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message);
            }
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        }

        private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}