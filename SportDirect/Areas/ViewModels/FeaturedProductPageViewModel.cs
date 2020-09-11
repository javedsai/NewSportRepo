using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Core.Models.Authentication.Response;
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
    public class FeaturedProductPageViewModel : BasePageViewModel
    {
        public string _handler;
        private bool _isSortWay;
        private string _Condition = string.Empty;
        private string _Name = string.Empty;
        private bool _gridIsvisible = false;
        private bool _isSortVisible;
        private bool _isSearchtWay;
        public bool IsSortVisible
        {
            get { return _isSortVisible; }
            set { _isSortVisible = value;RaisePropertyChanged(nameof(IsSortVisible)); }
        }

        public bool GridIsvisible
        {
            get => _gridIsvisible;
            set { _gridIsvisible = value; RaisePropertyChanged(); }
        }
        private string _title;

        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(nameof(Title)); }
        }

        //private ObservableCollection<CollectionProductListDataProducts> _productList;
        //public ObservableCollection<CollectionProductListDataProducts> ProductList
        //{
        //    get { return _productList; }
        //    set { _productList = value; RaisePropertyChanged(); }
        //}     
        private CollectionProductListDataProducts _productList;
        public CollectionProductListDataProducts ProductList
        {
            get { return _productList; }
            set { _productList = value; RaisePropertyChanged(); }
        }
        public ICommand SortCommand => new Command(async(obj) =>
        {
            _isSortWay = true;
             App.Locator.SortPage.InitilizeData(_handler);
            await App.Current.MainPage.Navigation.PushModalAsync(new SortPage());
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
                return new Command(async(obj) =>
                {
                    var CatagoriesByListData = obj as CollectionProductListDataEdge;
                    await App.Locator.ProductDetailsPage.InitializeData(CatagoriesByListData);
                    await App.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsPage());
                });
            }
        }
        private string _favoriteImage = "wishlistgrey";
        public string FavoriteImage
        {
            get { return _favoriteImage; }
            set { _favoriteImage = value; RaisePropertyChanged(); }
        }
        private string _searchText;
        private IApiService _apiService;
        public FeaturedProductPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
        }
        public async Task InitilizeData(string type)
        {
            _searchText = string.Empty;
            _handler = type;
            _isSortWay = false;
            _Condition = string.Empty;
            _Name = string.Empty;
            _isSearchtWay = false;
            char quote = '"';
            string modifiedCollectionName = quote + type + quote;
            try
            {
                string queryid_id = "{shop {name collectionByHandle(handle:" + modifiedCollectionName + ") {title handle products(first:20 ) {pageInfo { hasNextPage hasPreviousPage }edges { cursor node {id images(first:5){edges{node{id originalSrc}}} productType description variants(first: 50){edges{node{id available title selectedOptions{name value} price image{id originalSrc}}}} title}}}}}}";
                var res = await _apiService.GetCollectionListData(queryid_id);
                if (res?.data?.shop?.collectionByHandle != null)
                {
                    ProductList = new CollectionProductListDataProducts();
                    ProductList.edges=(res?.data?.shop?.collectionByHandle?.products.edges);
                    ProductList.pageInfo=(res?.data?.shop?.collectionByHandle?.products.pageInfo);

                    Title = res?.data?.shop?.collectionByHandle?.title;
                }
                else
                {
                }
            }
            catch
            {
                await ShowAlert("Internal Server Error");
            }
        }
        public void InitializeSortData(CollectionProductListDataProducts dataProducts, string type, string name, string condition)
        {
            _searchText = string.Empty;
            _isSearchtWay = false;
            _Condition = condition;
            _Name = name;
            ProductList = new CollectionProductListDataProducts();
            ProductList.edges = (dataProducts.edges);
            ProductList.pageInfo = (dataProducts.pageInfo);

            RaisePropertyChanged(nameof(ProductList));
        }
        public async Task InitilizeDataForSearch(string SearchText)
        {
            _isSearchtWay = true;
            _searchText = SearchText;
            UserDialogs.Instance.ShowLoading();
            try
            {
                char t = '"';
                var type = t + SearchText + t;
                string queryid_id = "{ shop{ products(first: 20, query:" + type + "){ pageInfo { hasNextPage hasPreviousPage } edges{ cursor node{id images(first: 5){ edges {node{ id src}}} title productType description variants(first: 50){ edges{ node{ id  available price title selectedOptions{name value} image{ id originalSrc} } } }}}}}}";
                var res = await _apiService.SortListOfProduct(queryid_id);
                 if (res.data.shop.products.edges.Count > 0)
                {
                    ProductList = new CollectionProductListDataProducts();
                    ProductList.edges = (res?.data?.shop?.products?.edges);
                    ProductList.pageInfo = (res?.data?.shop?.products.pageInfo);
                }
                else
                {
                    // getCategory.Clear();
                    await ShowAlert("This product is not available", "Ok");
                }
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert("Internal server error");
            }
            UserDialogs.Instance.HideLoading();
        }
        public ICommand ThresoldCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.ShowLoading();
            if (ProductList.pageInfo.hasNextPage)
                GetCollection(ProductList.edges.LastOrDefault().cursor);
            else
                UserDialogs.Instance.Toast("No More Data Available");
            UserDialogs.Instance.HideLoading();
        });

        private async void GetCollection(string afterData)
        {
            if(_isSearchtWay)
            {
                UserDialogs.Instance.ShowLoading();
                try
                {
                    char t = '"';
                    var type = t + _searchText + t;
                    string modifiedAfterCursor1 = t + afterData + t;
                    string queryid_id = "{ shop{ products(first: 20 after:" + modifiedAfterCursor1 + ", query:" + type + "){ pageInfo { hasNextPage hasPreviousPage } edges{ cursor node{id images(first: 5){ edges {node{ id src}}} title productType description variants(first: 50){ edges{ node{ id  available price title selectedOptions{name value} image{ id originalSrc} } } }}}}}}";
                    var res = await _apiService.SortListOfProduct(queryid_id);
                    if (res.data.shop.products.edges.Count > 0)
                    {
                        foreach(var item in res.data.shop.products.edges)
                        {
                            var data = ProductList.edges.Any(s => s.node.id.Equals(item.node.id));
                            if (!data)
                            {
                                ProductList.edges.Add(item);
                            }
                        }
                        //result.edges.AddRange(res.data.shop.products.edges);
                        RaisePropertyChanged(nameof(ProductList.edges));
                    }
                    else
                    {
                        // getCategory.Clear();
                       // await ShowAlert("This product is not available", "Ok");
                    }
                }
                catch (Exception ex)
                {
                    //UserDialogs.Instance.Alert("Internal server error");
                }
                UserDialogs.Instance.HideLoading();
            }
            else
            {
                char quote = '"';
                string modifiedCollectionName = quote + _handler + quote;
                string modifiedAfterCursor = quote + afterData + quote;
                try
                {
                    string queryid_id;
                    if (string.IsNullOrEmpty(_Condition) && string.IsNullOrEmpty(_Name))
                        queryid_id = "{shop {name collectionByHandle(handle:" + modifiedCollectionName + ") {title products(first:20 after:" + modifiedAfterCursor + " ) {pageInfo { hasNextPage hasPreviousPage }edges { cursor node {id images(first:5){edges{node{id originalSrc}}} productType description variants(first: 50){edges{node{id available title selectedOptions{name value} price image{id originalSrc}}}} title}}}}}}";
                    else
                        queryid_id = "{shop {name collectionByHandle(handle:" + modifiedCollectionName + ") {title products(first:20 after:" + modifiedAfterCursor + "," + "sortKey:" + _Name + "," + "reverse: " + _Condition + " ) {pageInfo { hasNextPage hasPreviousPage }edges { cursor node {id images(first:5){edges{node{id originalSrc}}} productType description variants(first: 50){edges{node{id available title selectedOptions{name value} price image{id originalSrc}}}} title}}}}}}";
                    var res = await _apiService.GetCollectionListData(queryid_id);
                    if (res.data.shop.collectionByHandle != null)
                    {
                        foreach (var item in res.data.shop.collectionByHandle.products.edges)
                        {
                            if (!ProductList.edges.Any(s => s.node.id == item.node.id))
                            {
                                ProductList.edges.Add(item);
                            }
                        }
                    }
                    else
                    {
                        UserDialogs.Instance.HideLoading();
                    }
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.HideLoading();
                    UserDialogs.Instance.Alert(ex.Message.ToString());
                }
            }
        }

        public ICommand FavoriteCommand => new Command((obj) =>
        {
              

        });
       
        public async Task<ObservableCollection<ProductViewModel>> GetProductList(string Product_type)
        {
            ObservableCollection<ProductViewModel> productViewModels = new ObservableCollection<ProductViewModel>();
            return productViewModels;
        }
    }
}