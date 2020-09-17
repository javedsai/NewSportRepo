using Acr.UserDialogs;
using FFImageLoading.Concurrency;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Assets;
using SportDirect.Data.Models.Common;
using SportDirect.Data.Models.Request;
using SportDirect.Data.Models.Response;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class ProductDetailsPageViewModel : BasePageViewModel
    {
        private CollectionProductListDataEdge _collectionListEdge;
        private string _pageTitle;
        public ObservableCollection<String> _carouselList = new ObservableCollection<String>();
        public ObservableCollection<String> CarouselList
        {
            get
            {
                return _carouselList;
            }
            set
            {
                if (_carouselList != value)
                {
                    _carouselList = value;
                    RaisePropertyChanged();
                }
            }
        }
        private ObservableCollection<ProductDetailModel> _customerReviewsList;
        public ObservableCollection<ProductDetailModel> CustomerReviewsList
        {
            get { return _customerReviewsList; }
            set { _customerReviewsList = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<ProductDetailModel> _relatedItemsList;
        public ObservableCollection<ProductDetailModel> RelatedItemsList
        {
            get { return _relatedItemsList; }
            set { _relatedItemsList = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<HomeModel> _featuredProdcut = new ObservableCollection<HomeModel>();
        public ObservableCollection<HomeModel> FeaturedProdcut
        {
            get { return _featuredProdcut; }
            set { _featuredProdcut = value; RaisePropertyChanged(); }
        }
        private NewArrivalModel _newArrival_Prodcut = new NewArrivalModel();
        public NewArrivalModel NewArrival_Prodcut
        {
            get { return _newArrival_Prodcut; }
            set { _newArrival_Prodcut = value; RaisePropertyChanged(); }
        }
        private HomeModel _featured_Prodcut = new HomeModel();
        public HomeModel Featured_Prodcut
        {
            get { return _featured_Prodcut; }
            set { _featured_Prodcut = value; RaisePropertyChanged(); }
        }

        public bool status;


        private string _Title_Variant;
        public string Title_Variant
        {
            get { return _Title_Variant; }
            set { _Title_Variant = value; RaisePropertyChanged(); }
        }
        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged(); }
        }


        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; RaisePropertyChanged(); }
        }

        private int _counter = 1;
        public int Counter
        {
            get { return _counter; }
            set { _counter = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<CollectionFilterModel> _listOfAttributes;

        public ObservableCollection<CollectionFilterModel> ListOfAttributes
        {
            get { return _listOfAttributes; }
            set { _listOfAttributes = value; RaisePropertyChanged(nameof(ListOfAttributes)); }
        }
        private bool _isBuyAvailable;
        public bool IsBuyAvailable
        {
            get { return _isBuyAvailable; }
            set { _isBuyAvailable = value; RaisePropertyChanged(); }
        }
        private string _buyNowText;
        public string BuyNowText
        {
            get { return _buyNowText; }
            set { _buyNowText = value; RaisePropertyChanged(nameof(BuyNowText)); }
        }
        CollectionProductListDataNode2 SelectedNode;
        public void FillFeaturedProduct(int ProductIndex)
        {
            try
            {
                Title_Variant = Convert.ToString(_featured_Prodcut.productName);
                //Price = Convert.ToString(_featured_Prodcut.variants[ProductIndex].price);
                Description = Convert.ToString(_featured_Prodcut.body_html);
                Id = _featured_Prodcut.ProductId;
                VariantId = _featured_Prodcut.variant_Id;
                Qantity = 1;
                Title = _featured_Prodcut.productName;
                //ImageUrl = _featured_Prodcut.image.src;
                TitleName = _featured_Prodcut.productName;

            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
        }
        public void FillProduct(int ProductIndex)
        {
            try
            {
                Title_Variant = Convert.ToString(_newArrival_Prodcut.TitleName);
                //  Price = Convert.ToString(_newArrival_Prodcut.variants[ProductIndex].price);
                Description = Convert.ToString(_newArrival_Prodcut.body_html);
                Id = _newArrival_Prodcut.ProductID;
                VariantId = _newArrival_Prodcut.variant_Id;
                Qantity = 1;
                Title = _newArrival_Prodcut.TitleName;
                //  ImageUrl = _newArrival_Prodcut.image.src;
                TitleName = _featured_Prodcut.productName;
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message.ToString());
            }
        }
        private IApiService _apiService;
        public ProductDetailsPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            _pageTitle = "CarouselViewChallege";
            CustomerReviewsList = GetCustomerReviewsList();
            RelatedItemsList = GetRelatedItemsList();

        }



        public ObservableCollection<ProductDetailModel> GetSizeList()
        {
            return new ObservableCollection<ProductDetailModel>()
            {
                new ProductDetailModel{ Size="4x6'' 8 feet",SizeTextColor="White",FrameBgColor="#EB0027"},
                new ProductDetailModel{ Size="4x8'' 10 feet",SizeTextColor="Gray",FrameBgColor="White"},
                new ProductDetailModel{ Size="5x6'' 12 feet",SizeTextColor="Gray",FrameBgColor="White"},
                new ProductDetailModel{ Size="4x8'' 12 feet",SizeTextColor="Gray",FrameBgColor="White"},
                new ProductDetailModel{ Size="4x8'' 10 feet",SizeTextColor="Gray",FrameBgColor="White"},
                new ProductDetailModel{ Size="5x6'' 12 feet",SizeTextColor="Gray",FrameBgColor="White"},
                new ProductDetailModel{ Size="4x8'' 12 feet",SizeTextColor="Gray",FrameBgColor="White"},
            };
        }

        public ObservableCollection<ProductDetailModel> GetCustomerReviewsList()
        {
            return new ObservableCollection<ProductDetailModel>()
            {
                new ProductDetailModel{ ProductImages="cicedepoutre"},
                new ProductDetailModel{ ProductImages="cicedepoutre" },
                new ProductDetailModel{ ProductImages="cicedepoutre"},
                new ProductDetailModel{ ProductImages="cicedepoutre"},
                new ProductDetailModel{ ProductImages="cicedepoutre"},
                new ProductDetailModel{ ProductImages="cicedepoutre"}
           };
        }
        public ObservableCollection<ProductDetailModel> GetRelatedItemsList()
        {
            return new ObservableCollection<ProductDetailModel>()
            {
                new ProductDetailModel{ ProductImages="crash2", productName="Gymnastic mats",ProductPrice="$139.95", Rating="3",ProductForwardImages="BlackForward" },
                new ProductDetailModel{ ProductImages="crash2", productName="Gymnastic mats",ProductPrice="$495.00",Rating="4",ProductForwardImages="BlackForward" },
                new ProductDetailModel{ ProductImages="crash2", productName="Gymnastic mats",Rating="5",ProductPrice="$ 139.95",ProductForwardImages="BlackForward" },
                new ProductDetailModel{ ProductImages="crash2", productName="Gymnastic mats",ProductPrice="$139.95",Rating="3",ProductForwardImages="BlackForward" },
                new ProductDetailModel{ ProductImages="crash2", productName="Fall mattress",ProductPrice="$495.00",Rating="4",ProductForwardImages="BlackForward" },
                new ProductDetailModel{ ProductImages="crash2", productName="Gymnastic mats",ProductPrice="$ 495.00",Rating="5",ProductForwardImages="BlackForward" }
           };
        }

        public async Task InitializeData(CollectionProductListDataEdge catagoriesByListData)
        {
            try
            {
                SelectedNode = null;
                CarouselList.Clear();
                _collectionListEdge = catagoriesByListData;
                CarouselList = new ObservableCollection<String>();
                foreach (var item in catagoriesByListData.node.images.edges)
                {
                    CarouselList.Add(item.node.originalSrc);
                }
                RaisePropertyChanged(nameof(CarouselList));
                Title = catagoriesByListData.node.title;
                Price = catagoriesByListData.node.variants.edges[0].node.price;
                Description = catagoriesByListData.node?.description;
                Counter = 1;
                TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
                ListOfAttributes = new ObservableCollection<CollectionFilterModel>();
                try
                {
                    foreach (var varient in _collectionListEdge.node.variants.edges)
                    {
                        bool i = false;
                        foreach (var option in varient.node.selectedOptions)
                        {
                            var item = new Data.Models.Common.Data();
                            if (!i)
                            {
                                SelectedNode = new CollectionProductListDataNode2();
                                SelectedNode = varient.node;
                                item.IsSelected = true;
                                item.BorderCol = "Black";
                                i = true;
                            }
                            else
                            {
                                item.IsSelected = false;
                                item.BorderCol = "White";
                                i = false;
                            }
                            if (ListOfAttributes.Any(s => s.AttributeName == option.name))
                            {
                                //Available
                                var findattribute = ListOfAttributes.FirstOrDefault(s => s.AttributeName == option.name);
                                if (!findattribute.datas.Any(s => s.VarientValue == option.value))
                                {
                                    item.VarientId = varient.node.id; item.VarientName = option.name; item.VarientValue = option.value;
                                    findattribute.datas.Add(item);
                                }
                            }
                            else
                            {
                                //not available
                                CollectionFilterModel datas = new CollectionFilterModel();
                                datas.AttributeName = option.name;
                                datas.datas = new List<Data.Models.Common.Data>();
                                item.VarientId = varient.node.id; item.VarientName = option.name; item.VarientValue = option.value;
                                datas.datas.Add(item);
                                ListOfAttributes.Add(datas);
                            }
                        }
                    }
                    if (ListOfAttributes != null)
                    {
                        for (int i = 0; i < ListOfAttributes.Count; i++)
                        {
                            if (ListOfAttributes[i].datas != null)
                            {
                                ListOfAttributes[i].datas[0].IsSelected = true;
                                ListOfAttributes[i].datas[0].BorderCol = "Black";
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    ShowAlert(ex.Message);
                }

            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public ICommand CheckAvailibilityCmd => new Command(async (obj) =>
        {
            List<Data.Models.Common.Data> datas = new List<Data.Models.Common.Data>();
            foreach (var item in ListOfAttributes)
            {
                var selectedItem = item.datas.Where(x => x.IsSelected).FirstOrDefault();
                if (selectedItem != null)
                    datas.Add(selectedItem);
            }
            bool isFound = false;
            foreach (var edges in _collectionListEdge.node.variants.edges)
            {
                foreach (var attNode in datas)
                {
                    isFound = edges.node.selectedOptions.Any(s => s.name == attNode.VarientName && s.value == attNode.VarientValue);
                    if (!isFound)
                    {
                        break;
                    }
                }
                if (isFound)
                {
                    if (edges.node.available)
                    {
                        IsBuyAvailable = true;
                        BuyNowText = "Buy Now";
                    }
                    else
                    {
                        IsBuyAvailable = false;
                        BuyNowText = "Sold Out";
                    }
                    CarouselList.Clear();
                    CarouselList.Add(edges.node.image.originalSrc);
                    SelectedNode = edges.node;
                    break;
                }

            }
            if (!isFound)
            {
                IsBuyAvailable = false;
                BuyNowText = "Sold Out";
            }

            if (!isFound)
            {
                await ShowAlert("Combination not found");
            }

        });

        public ICommand ShareCommand => new Command(async (obj) =>
        {
            await Share.RequestAsync("Coming Soon");
        });
        public ICommand FrameBgColorCommand => new Command(async (obj) =>
        {

            //UserDialogs.Instance.Alert("Coming Soon");


            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ProductDetailModel PrevColor { get; set; }
        public ICommand SizeSelectCommand => new Command((obj) =>
        {
            try
            {
                UserDialogs.Instance.ShowLoading();
                var obj2 = obj as ProductDetailModel;
                Price = Convert.ToString(obj2.ProductPrice);
                UserDialogs.Instance.HideLoading();
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message);
            }
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ICommand FastDeliveryCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.Alert("Coming Soon");
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ICommand ProductReturnCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.Alert("Coming Soon");
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ICommand SatisfactionCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.Alert("Coming Soon");
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ICommand SeeAllCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.Alert("Coming Soon");
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        public ICommand CustomerReviewsCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.Alert("Coming Soon");
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });
        private bool Check = false;
        private string _wishImage = "wishlistgrey";
        public string WishImage
        {
            get => _wishImage;
            set { _wishImage = value; RaisePropertyChanged(); }
        }
        public ICommand WishCommand => new Command(async (obj) =>
        {
            if (Check == false)
            {
                WishImage = "wishlistgrey";
                Check = true;
            }
            else
            {
                WishImage = "wishlist";
                Check = false;
            }
        });
        public ICommand RelatedItemsCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.Alert("Coming Soon");
            //await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        });

        //public void Init(HomeModel obj_HomeModal)
        //{
        //    status = false;
        //    Featured_Prodcut = obj_HomeModal;
        //    CarouselList = GetCarouselList(obj_HomeModal);
        //    FrameColorList = GetFrameColorList(obj_HomeModal);
        //    FillFeaturedProduct(0);
        //}
        //public void Init(NewArrivalModel obj_NewArrival)
        //{
        //    status = true;
        //    NewArrival_Prodcut = obj_NewArrival;
        //    _newArrival_Prodcut = obj_NewArrival;
        //    CarouselList = GetCarouselList(obj_NewArrival);
        //    FrameColorList = GetFrameColorList(obj_NewArrival);
        //    FillProduct(0);
        //}


        private string _id;
        public string Id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged(); }
        }
        private long _variantId;
        public long VariantId
        {
            get { return _variantId; }
            set { _variantId = value; RaisePropertyChanged(); }
        }
        private int _quantity1;
        public int Qantity
        {
            get { return _quantity1; }
            set { _quantity1 = value; RaisePropertyChanged(); }
        }
        private string _titleName;
        public string TitleName
        {
            get { return _titleName; }
            set { _titleName = value; }
        }

        private string _imageUrl;
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public ICommand BuyNowCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.ShowLoading();
            var address = await App.Locator.CartPage.GetAddressInfor();
            if (address != null)
            {
                try
                {
                    if (string.IsNullOrEmpty(Settings.CheckoutId))
                    {
                        //Check out Id is not found
                        CheckoutRequestModel request = new CheckoutRequestModel();
                        Inputs inputs = new Inputs();
                        request.input = inputs;
                        request.input.email = Settings.Customer_Email;
                        request.input.note = "hello";
                        request.input.lineItems = new List<Data.Models.Request.LineItem>();
                        request.input.lineItems.Add(new Data.Models.Request.LineItem
                        {
                            quantity = Counter,
                            variantId = SelectedNode.id
                        });

                        Data.Models.Request.ShippingAddress shipping = new Data.Models.Request.ShippingAddress();

                        request.input.shippingAddress = shipping;
                        request.input.shippingAddress.firstName = address[0].node.firstName;
                        request.input.shippingAddress.lastName = address[0].node.lastName;
                        request.input.shippingAddress.address1 = address[0].node.address1;
                        request.input.shippingAddress.address2 = address[0].node.address2;
                        request.input.shippingAddress.city = address[0].node.city;
                        request.input.shippingAddress.country = address[0].node.country;
                        request.input.shippingAddress.zip = address[0].node.zip;
                        request.input.shippingAddress.phone = address[0].node.phone;
                        request.input.shippingAddress.province = address[0].node.province;
                        request.input.shippingAddress.company = address[0].node.company;
                        var queryId = @"mutation checkoutCreate($input: CheckoutCreateInput!) {
                          checkoutCreate(input: $input) {
                            checkout {
                              id
                            }
                            checkoutUserErrors {
                              code
                              field
                              message
                            }
                          }
                        }
                        ";
                        var res1 = await _apiService.CheckOutData(queryId, request);
                        if (string.IsNullOrEmpty(res1.data.checkoutCreate.checkout.id))
                        {
                            await ShowAlert("Checkout not created");
                        }
                        else
                        {
                            Settings.CheckoutId = res1.data.checkoutCreate.checkout.id;
                            var queryCustomerAssociate = @"mutation checkoutCustomerAssociateV2($checkoutId: ID!, $customerAccessToken: String!) {
                              checkoutCustomerAssociateV2(checkoutId: $checkoutId, customerAccessToken: $customerAccessToken) {
                                checkout {
                                  id
                                }
                                checkoutUserErrors {
                                  code
                                  field
                                  message
                                }
                                customer {
                                  id
                                }
                              }
                            }";
                            CheckOutCustomerRequestModel checkOut = new CheckOutCustomerRequestModel();
                            checkOut.checkoutId = Settings.CheckoutId;
                            checkOut.customerAccessToken = Settings.Customer_Access_Token;
                            var checkOutAssociateResponse = await _apiService.CheckOutAssociate(queryCustomerAssociate, checkOut);
                            if (checkOutAssociateResponse.data.checkoutCustomerAssociateV2.checkout.id != null)
                            {
                                await App.Locator.CartPage.InitilizeData();
                                await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
                            }
                        }
                    }
                    else
                    {
                        //Check out Id is found
                        var queryLineId = @"mutation checkoutLineItemsAdd($lineItems: [CheckoutLineItemInput!]!, $checkoutId: ID!) {
                                      checkoutLineItemsAdd(lineItems: $lineItems, checkoutId: $checkoutId) {
                                        checkout {
                                          id
                                        }
                                        checkoutUserErrors {
                                          code
                                          field
                                          message
                                        }
                                      }
                                    }
                                    ";
                        LineItemRequest lineItem = new LineItemRequest();
                        lineItem.checkoutId = Settings.CheckoutId;
                        lineItem.lineItems = new List<Data.Models.Response.LineItemsInfo>();
                        lineItem.lineItems.Add(new Data.Models.Response.LineItemsInfo
                        {
                            quantity = Counter,
                            variantId = SelectedNode.id
                        });
                        var res = await _apiService.LineItemData(queryLineId, lineItem);
                        if (string.IsNullOrEmpty(res.data.checkoutLineItemsAdd.checkout.id))
                        {
                            //Unable to add cart
                            await ShowAlert("Product doesn't added into the cart successfully");
                        }
                        else
                        {
                            //cart added
                            await App.Locator.CartPage.InitilizeData();
                            await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());

                            // await _navigationService.ShellNavigationPushAsync(new CartPage());
                        }
                    }
                }
                catch (Exception ex)
                {
                    ex.Message.ToString();
                }
            }
            else
            {
                UserDialogs.Instance.Alert("Please provide address");
            }
            UserDialogs.Instance.HideLoading();

        });
        public async void GetProductList(string Product_type)
        {
            //try
            //{
            //    var res = await _apiService.GetProduct(App.Access_User, App.Access_Pass, Product_type);
            //    if (res != null)
            //    {
            //        foreach (var item in res.products)
            //        {
            //            HomeModel obj_modal = new HomeModel();
            //            obj_modal.ProductId = Convert.ToString(item.id);
            //            obj_modal.ProductImages = "LoadIcon.png";
            //            obj_modal.productName = item.title;
            //            obj_modal.ProductPrice = item.variants[0].price;
            //            obj_modal.Rating = "4";
            //            obj_modal.ProductForwardImages = "BlackForward";
            //            obj_modal.ProductColor = "#9FDCEE";

            //            //       ProductList.Add(obj_modal);
            //        }
            //    }
            //    else
            //    {
            //        // ProductList.Clear();
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