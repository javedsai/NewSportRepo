using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Data.Models.Response;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class ProductViewPageViewModel : BasePageViewModel
    {
        private bool _gridIsvisible = false;
        public bool GridIsvisible
        {
            get => _gridIsvisible;
            set { _gridIsvisible = value; RaisePropertyChanged(); }
        }

       

        private string _imageNewArrivals = "CheckGreen";
        public string ImageNewArrivals
        {
            get => _imageNewArrivals;
            set { _imageNewArrivals = value; RaisePropertyChanged(); }
        }
        private string _imageFeatured = "Uncheck";
        public string ImageFeatured
        {
            get => _imageFeatured;
            set { _imageFeatured = value; RaisePropertyChanged(); }
        }
        private string _imageBestsellers = "Uncheck";
        public string ImageBestsellers
        {
            get => _imageBestsellers;
            set { _imageBestsellers = value; RaisePropertyChanged(); }
        }
        //private ObservableCollection<ProductsEdge> _productList = new ObservableCollection<ProductsEdge>();
        //public ObservableCollection<ProductsEdge> ProductList
        //{
        //    get { return _productList; }
        //    set { _productList = value; RaisePropertyChanged(); }
        //}
        public ICommand NewArrivalsCommand => new Command(async (obj) =>
         {
             ImageNewArrivals = "CheckGreen";
             ImageFeatured = "Uncheck";
             ImageBestsellers = "Uncheck";
         });
        public ICommand FeaturedCommand => new Command(async (obj) =>
         {
             ImageNewArrivals = "Uncheck";
             ImageFeatured = "CheckGreen";
             ImageBestsellers = "Uncheck";
         });
        public ICommand BestsellersCommand => new Command(async (obj) =>
         {
             ImageNewArrivals = "Uncheck";
             ImageFeatured = "Uncheck";
             ImageBestsellers = "CheckGreen";
         });
        public ICommand SelectCategoryCommand => new Command(async (obj) =>
         {
             if (GridIsvisible == false)
             {
                 GridIsvisible = true;
             }
             else
             {
                 GridIsvisible = false;
             }
         });
        public ICommand SortCommand => new Command(async (obj) =>
         {
             GridIsvisible = false;
         });
        public ICommand FilterCommand => new Command(async (obj) =>
         {
             GridIsvisible = false;
             await App.Current.MainPage.Navigation.PushModalAsync(new FilterPage());
         });
        public Command ProductCommand
        {
            get
            {
                return new Command(async (obj) =>
                {
                    //var CatagoriesByListData = obj as ProductsEdge;
                    //App.Locator.ProductDetailsPage.InitializeData(CatagoriesByListData);
                    //App.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsPage(CatagoriesByListData));
                    //await App.Current.MainPage.Navigation.PushModalAsync(new ProductsPage());
                });
            }
        }
        private string _favoriteImage = "wishlistgrey";
        public string FavoriteImage
        {
            get { return _favoriteImage; }
            set { _favoriteImage = value; RaisePropertyChanged(); }
        }
        private IApiService _apiService;

        public ProductViewPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            // ProductList = GetProductList();
        }
        public async Task SeeAllProduct()
        {

            UserDialogs.Instance.ShowLoading();
            try
            {
                string queryid_id = "{shop{products(first: 50){edges{node{id images(first: 5){ edges {node{ id src}}} title productType description variants(first: 3){ edges{ node{ id price title selectedOptions{name value} image{ id originalSrc} } } }}}}}}    ";
                var res = await _apiService.GetProduct(queryid_id);

                if (res != null)
                {
                    //ProductList = new ObservableCollection<ProductsEdge>(res.Data.Shop.Products.Edges);
                    //ProductsEdge products = new ProductsEdge();
                    //var filterData = ProductList.Where(s => s.Node.productType == "Heavy Bags").ToList();
                    //ProductList = new ObservableCollection<ProductsEdge>(filterData);
                }
                else
                {
                    // getCategory.Clear();
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.HideLoading();
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
            UserDialogs.Instance.HideLoading();

        }
        public void Init()
        {
            GetNewArrivalList("New Arrival");
        }




        //item.Favorite = "wishlist";
        //item.Favorite = "wishlistgrey";
        public ICommand FavoriteCommand => new Command(async (obj) =>
        {
            //ProductList = GetProductList();
            //var favoritItem = obj as ProductViewModel;  
            //if(favoritItem!=null)
            //{
            //    if (FavoriteImage == favoritItem.Favorite)
            //    {
            //        favoritItem.Favorite = "wishlist";
            //        FavoriteImage = "wishlist";
            //        //item.Favorite = false;
            //    }
            //    else
            //    {
            //        favoritItem.Favorite = "wishlistgrey";
            //        FavoriteImage = "wishlistgrey";
            //    }
            //    foreach (var item in ProductList)
            //    {
            //        item.Favorite = FavoriteImage;
            //    }
            //}         
        });
        public ObservableCollection<ProductViewModel> GetProductList()
        {
            return new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel{Image= "productview", Favorite= "wishlistgrey", Title="Aluminum bench de joueurs",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel", Favorite = "wishlist", Title ="Ice Divider board",Rating="5",Price="$119995.00" },
                new ProductViewModel{Image= "productview",Favorite= "wishlistgrey", Title="Aluminum bench de joueurs",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel",Favorite= "wishlistgrey", Title="Ice Divider board",Rating="5",Price="$119995.00" },
                new ProductViewModel{Image= "productview",Favorite= "wishlistgrey", Title="Aluminum bench de joueurs",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel",Favorite= "wishlistgrey", Title="Aluminum bench de joueurs",Rating="5",Price="$119995.00" },
                new ProductViewModel{Image= "productview",Favorite= "wishlistgrey", Title="Ice Divider board",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel", Favorite= "wishlistgrey",Title="Aluminum bench de joueurs",Rating="5",Price="$119995.00" },
            };
        }
        public async void GetNewArrivalList(string product_type)
        {
            //try
            //{
            //    UserDialogs.Instance.ShowLoading();
            //    var res = await _apiService.GetProduct(App.Access_User, App.Access_Pass, product_type);
            //    UserDialogs.Instance.HideLoading();
            //    if (res != null)
            //    {
            //        foreach (var item in res.products)
            //        {
            //            ProductViewModel obj_modal = new ProductViewModel()
            //            {
            //                Image = "LoadIcon.png",
            //                Favorite = "wishlistgrey",
            //                Title = item.title,
            //                Rating = "4",
            //                Price = item.variants[0].price
            //            };
            //            ProductList.Add(obj_modal);
            //        }
            //    }
            //    else
            //    {
            //        ProductList.Clear();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    UserDialogs.Instance.HideLoading();
            //    UserDialogs.Instance.Alert(ex.Message.ToString());
            //}

        }
    }
}