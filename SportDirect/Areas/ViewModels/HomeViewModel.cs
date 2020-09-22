using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Assets;
using SportDirect.Core.Models.Authentication.Response;
using SportDirect.Core.Models.User;
using SportDirect.Data.Models.Common;
using SportDirect.Data.Models.Response;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class HomeViewModel : BasePageViewModel
    {
        private string _pageTitle;
        private string _bgImage;
        public string BgImage
        {
            get { return _bgImage; }
            set { _bgImage = value; RaisePropertyChanged(); }
        }
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; RaisePropertyChanged(SearchText); }
        }

        private ObservableCollection<HomeModel> _carouselList;
        public ObservableCollection<HomeModel> CarouselList
        {
            get { return _carouselList; }
            set { _carouselList = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<CategoryCommonModel> _categoriesImagesList;
        public ObservableCollection<CategoryCommonModel> CategoriesImagesList
        {
            get { return _categoriesImagesList; }
            set { _categoriesImagesList = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<CollectionProductListDataProducts> _featuredProduct;
        public ObservableCollection<CollectionProductListDataProducts> FeaturedProduct
        {
            get { return _featuredProduct; }
            set { _featuredProduct = value; RaisePropertyChanged(nameof(FeaturedProduct)); }
        }
        private ObservableCollection<CollectionProductListDataProducts> _newArrivalList;
        public ObservableCollection<CollectionProductListDataProducts> NewArrivalList
        {
            get { return _newArrivalList; }
            set { _newArrivalList = value; RaisePropertyChanged(); }
        }

        private IApiService _apiService;
        public HomeViewModel(IApiService apiService)
        {
            _apiService = apiService;
            _pageTitle = "CarouselViewChallege";
            BgImage = "banner";
            CarouselList = GetCarouselList();
        }
        public ObservableCollection<HomeModel> GetCarouselList()
        {
            return new ObservableCollection<HomeModel>()
            {
                new HomeModel{ CarouselImages="banner",},
                new HomeModel{ CarouselImages="banner",},
                new HomeModel{ CarouselImages="banner",},
                new HomeModel{ CarouselImages="banner",},
            };
        }
        public ObservableCollection<HomeModel> GetCategoriesImagesList()
        {
            return new ObservableCollection<HomeModel>()
            {
                new HomeModel{ CategoriesImages="Customers1", CategoriesName="Customers", CategoriesColor="#FF7BA0"},
                new HomeModel{ CategoriesImages="Products1", CategoriesName="Products", CategoriesColor="#6BD1A8"},
                new HomeModel{ CategoriesImages="Sport1", CategoriesName="Sports", CategoriesColor="#6B94D1"}
            };
        }
      
        //Api For H
        public async Task GetCollectionList()
        {
          
                try
                {
                    string queryid_id = "{shop {name collections(first: 50) {edges {node { id handle image {id originalSrc} title }}}}}";
                await Task.Delay(2000);
                    var res = await _apiService.GetCollection(queryid_id);
                    if (res != null)
                    {
                        CategoriesImagesList = new ObservableCollection<CategoryCommonModel>();
                        foreach (var item in res?.data?.shop?.collections?.edges)
                        {
                            CategoriesImagesList.Add(new CategoryCommonModel
                            {
                                Id = item.node.id,
                                image = string.IsNullOrEmpty(item?.node?.image?.originalSrc) ? "Sports1.png" : item?.node?.image?.originalSrc,
                                title = item.node.title,
                                handle = item.node.handle
                            });
                        }
                    }
                    else
                    {
                    }
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert("Internal Server Error");
                }
           
        }

        public ICommand SearchCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.ShowLoading();
            await App.Locator.FeaturedProductPage.InitilizeDataForSearch(SearchText);
            await App.Current.MainPage.Navigation.PushModalAsync(new FeaturedProductPage(true));
            UserDialogs.Instance.HideLoading();

        }); 
            public ICommand SeeAllCategoryCommand => new Command(async (obj) =>
            {
                UserDialogs.Instance.ShowLoading();
                await App.Locator.CustomersPage.InitilizeData(CategoriesImagesList);
                await App.Current.MainPage.Navigation.PushModalAsync(new CustomersPage(_apiService));
                UserDialogs.Instance.HideLoading();

            });

        public async Task GetFeaturedProductList()
        {
           
                try
                {
                    var result = await GetProductByHandler("produits-pour-la-rentree-des-classes");
                    List<CollectionProductListDataProducts> data = new List<CollectionProductListDataProducts>();
                    foreach (var item in result)
                    {
                        ObservableCollection<CollectionProductListDataEdge> req = new ObservableCollection<CollectionProductListDataEdge>();
                        foreach (var val in item.edges)
                        {
                            CollectionProductListDataEdge d1 = new CollectionProductListDataEdge
                            {
                                cursor = val.cursor,
                                node = val.node
                            };
                            req.Add(d1);
                            if (req.Count == 3)
                                break;
                        }
                        data.Add(new CollectionProductListDataProducts
                        {
                            edges = req,
                            pageInfo = item.pageInfo
                        });
                    }
                    FeaturedProduct = new ObservableCollection<CollectionProductListDataProducts>(data);
                }
                catch (Exception ex)
                {
                    UserDialogs.Instance.Alert(ex.Message.ToString());
               }
            
           
           

        }
        public async Task GetNewProductList()
        {
          
                try
                {
                    var result = await GetProductByHandler("nouveaux-produits-recemment-ajoutes");
                    List<CollectionProductListDataProducts> data = new List<CollectionProductListDataProducts>();
                    foreach (var item in result)
                    {
                    ObservableCollection<CollectionProductListDataEdge> req = new ObservableCollection<CollectionProductListDataEdge>();
                        foreach (var val in item.edges)
                        {
                            CollectionProductListDataEdge d1 = new CollectionProductListDataEdge
                            {
                                cursor = val.cursor,
                                node = val.node
                            };
                            req.Add(d1);
                            if (req.Count == 3)
                                break;
                        }
                        data.Add(new CollectionProductListDataProducts
                        {
                            edges = req,
                            pageInfo = item.pageInfo
                        });
                    }
                    NewArrivalList = new ObservableCollection<CollectionProductListDataProducts>(data);
                }
                catch (Exception ex)
                {
                   
                    UserDialogs.Instance.Alert(ex.Message.ToString());
                }
            
           
           

        }
        public async Task<ObservableCollection<NewArrivalModel>> GetNewArrivalList(string product_type)
        {
            ObservableCollection<NewArrivalModel> newArrivalModels = new ObservableCollection<NewArrivalModel>();

            return newArrivalModels;
        }
        public ICommand CategoriesCommand => new Command(async (obj) =>
        {
            var categoryData = obj as CategoryCommonModel;
            UserDialogs.Instance.ShowLoading();
            await App.Locator.FeaturedProductPage.InitilizeData(categoryData.handle);
            await App.Current.MainPage.Navigation.PushModalAsync(new FeaturedProductPage(false));
            UserDialogs.Instance.HideLoading();
        });
        public ICommand BellNotificationCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new NotificationPage());
        });
        public ICommand CartCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });

        public Command CustomersCommand
        {
            get
            {
                return new Command(async () =>
                {
                    //await App.Current.MainPage.Navigation.PushModalAsync(new CustomersPage());
                });
            }
        }
        public Command ProductsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new ProductsPage());
                });
            }
        }
        public Command SportsCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new SportPage());
                });
            }
        }
        public Command SeeAllFeaturedProduct
        {
            get
            {
                return new Command(async () =>
                {

                    UserDialogs.Instance.ShowLoading();
                    string NewArrivalHandler = string.Empty;
                    var cultureName = CultureInfo.CurrentCulture.Name;
                    if (cultureName == "en-US")
                    {
                        NewArrivalHandler = "produits-pour-la-rentree-des-classes";
                    }
                    else
                    {
                        NewArrivalHandler = "produits-pour-la-rentree-des-classes";
                    }
                    await App.Locator.FeaturedProductPage.InitilizeData(NewArrivalHandler);
                    await App.Current.MainPage.Navigation.PushModalAsync(new FeaturedProductPage(false));
                    UserDialogs.Instance.HideLoading();
                });
            }
        }
        public Command SeeAllNewArrival
        {
            get
            {
                return new Command(async () =>
                {
                    UserDialogs.Instance.ShowLoading();
                    string NewArrivalHandler = string.Empty;
                    var cultureName = CultureInfo.CurrentCulture.Name;
                    if(cultureName == "en-US")
                    {
                        NewArrivalHandler = "nouveaux-produits-recemment-ajoutes";
                    }
                    else
                    {
                        NewArrivalHandler = "nouveaux-produits-recemment-ajoutes";
                    }
                    await App.Locator.FeaturedProductPage.InitilizeData(NewArrivalHandler);
                    await App.Current.MainPage.Navigation.PushModalAsync(new FeaturedProductPage(false));
                    UserDialogs.Instance.HideLoading();
                });
            }
        }

        public ICommand ProductCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.ShowLoading();
            var CatagoriesByListData = obj as CollectionProductListDataEdge;
            await App.Locator.ProductDetailsPage.InitializeData(CatagoriesByListData);
            await App.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsPage());
            UserDialogs.Instance.HideLoading();
        });

        public ICommand NewArrivalDetailsCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.ShowLoading();

            var CatagoriesByListData = obj as CollectionProductListDataEdge;
            await App.Locator.ProductDetailsPage.InitializeData(CatagoriesByListData);
            await App.Current.MainPage.Navigation.PushModalAsync(new ProductDetailsPage());
            UserDialogs.Instance.HideLoading();
        });
        private async Task<ObservableCollection<CollectionProductListDataProducts>> GetProductByHandler(string type)
        {
            ObservableCollection<CollectionProductListDataProducts> response = new ObservableCollection<CollectionProductListDataProducts>();
            char quote = '"';
            string modifiedCollectionName = quote + type + quote;
           
                try
                {
                    string queryid_id = "{shop {name collectionByHandle(handle:" + modifiedCollectionName + ") {title handle products(first:5 ) {pageInfo { hasNextPage hasPreviousPage }edges { cursor node {id images(first:5){edges{node{id originalSrc}}} productType description variants(first: 50){edges{node{id available title selectedOptions{name value} price image{id originalSrc}}}} title}}}}}}";
                await Task.Delay(2000);
                var res = await _apiService.GetCollectionListData(queryid_id);
                    if (res?.data?.shop?.collectionByHandle != null)
                    {
                        response.Add(res?.data?.shop?.collectionByHandle?.products);
                    }
                    else
                    {
                    }
                }
                catch
                {
                    await ShowAlert("Internal Server Error");
                }
                
            return response;
        }
    }
}