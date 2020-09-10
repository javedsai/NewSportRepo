using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.Assets;
using SportDirect.Data.Models.Request;
using SportDirect.Data.Models.Response;
using SportDirect.Helpers;
using SportDirect.Service.Interfaces;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class CartPageViewModel : BasePageViewModel
    {
        IApiService _apiService;
        LastIncompleteCheckout _lastIncomplete;
        private ObservableCollection<Node> _cartList;
        public ObservableCollection<Node> CartList
        {
            get { return _cartList; }
            set { _cartList = value; RaisePropertyChanged(); }
        }
        private string _couponCode;
        public string CouponCode
        {
            get { return _couponCode; }
            set { _couponCode = value; RaisePropertyChanged(); }
        }
        private bool _isPaymentEnabled;

        public bool IsPaymentEnabled
        {
            get { return _isPaymentEnabled; }
            set { _isPaymentEnabled = value; RaisePropertyChanged(nameof(IsPaymentEnabled)); }
        }
        private double _shippingPrice;
        public double ShippingPrice
        {
            get { return _shippingPrice; }
            set { _shippingPrice = value; RaisePropertyChanged(nameof(ShippingPrice)); }
        }
        private double _totalPrice;
        public double TotalPrice
        {
            get { return _totalPrice; }
            set { _totalPrice = value; RaisePropertyChanged(nameof(TotalPrice)); }
        }
        private double _costSummary;
        public double CostSummary
        {
            get { return _costSummary; }
            set { _costSummary = value; RaisePropertyChanged(nameof(CostSummary)); }
        }
        private int _totalQuantity;

        public int TotalQuantity
        {
            get { return _totalQuantity; }
            set { _totalQuantity = value; RaisePropertyChanged(nameof(TotalQuantity)); }
        }

        private string _pONumber;
        public string PONumber
        {
            get { return _pONumber; }
            set { _pONumber = value; RaisePropertyChanged(); }
        }
        private ObservableCollection<NewArrivalModel> _newArrivalList;
        public ObservableCollection<NewArrivalModel> NewArrivalList
        {
            get { return _newArrivalList; }
            set { _newArrivalList = value; RaisePropertyChanged(); }
        }

        public CartPageViewModel(IApiService apiService)
        {
            _apiService = apiService;
            NewArrivalList = GetNewArrivalList();
            foreach (var item in NewArrivalList)
            {
                if (int.Parse(item.Rating) == 3)
                {
                    item.star1 = "star";
                    item.star2 = "star";
                    item.star3 = "star";
                    item.star4 = "unfilledStar";
                    item.star5 = "unfilledStar";
                }
                else if (int.Parse(item.Rating) == 4)
                {
                    item.star1 = "star";
                    item.star2 = "star";
                    item.star3 = "star";
                    item.star4 = "star";
                    item.star5 = "unfilledStar";
                }
                else if (int.Parse(item.Rating) == 5)
                {
                    item.star1 = "star";
                    item.star2 = "star";
                    item.star3 = "star";
                    item.star4 = "star";
                    item.star5 = "star";
                }
            }
        }

        private string _total;

        public string Total
        {
            get { return _total; }
            set { _total = value; RaisePropertyChanged(); }
        }

        private double _quantity;

        public double Quantity
        {
            get { return _quantity; }
            set { _quantity = value; RaisePropertyChanged(); }
        }




        public async void Init()
        {
            //  CartList = await GetCartList();

        }
        public async Task<ObservableCollection<CartModel>> GetCartList()
        {
            List<Mycart> obj_mycart = new List<Mycart>();
            ObservableCollection<CartModel> newArrivalModels = new ObservableCollection<CartModel>();
            obj_mycart = await App.Database.GetCart();
            foreach (var item in obj_mycart)
            {
                newArrivalModels.Add(new CartModel()
                {
                    Image = item.NewArrivalImages,
                    Title = item.TitleName,
                    ProductColor = "#0000FF",
                    Qty = Convert.ToString(item.quantity),
                    Price = item.Price,
                    MinusImage = "Minus",
                    PlusImage = "Plus",
                    Counter = item.quantity,
                    variant_Id = item.VariantId,
                    ProductID = item.ProductID,
                    TitleName = item.TitleName,
                    NewArrivalImages = item.NewArrivalImages
                });
            }
            await Total1();
            return newArrivalModels;
            //  return new ObservableCollection<CartModel>()
            //  {
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
            //      new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },

            //};
        }
        public ObservableCollection<NewArrivalModel> GetNewArrivalList()
        {
            return new ObservableCollection<NewArrivalModel>()
            {
                new NewArrivalModel{ NewArrivalImages ="SG2",TitleName ="Professional steps adjustable in 3 height",Price="$219.00", Rating="5",StackLayoutIsVisible1 =true},
                new NewArrivalModel{ NewArrivalImages ="SG",TitleName ="Foldable Practice Beam",Price="$219.00", Rating="4",StackLayoutIsVisible1 =true},
                new NewArrivalModel{ NewArrivalImages ="SG2",TitleName ="Professional steps adjustable in 3 height",Price="$219.00", Rating="5",StackLayoutIsVisible1 =true},
                new NewArrivalModel{ NewArrivalImages ="SG",TitleName ="Foldable Practice Beam",Price="$219.00", Rating="4",StackLayoutIsVisible1 =true},
                new NewArrivalModel{ NewArrivalImages ="SG",TitleName ="Foldable Practice Beam",Price="$219.00", Rating="4",StackLayoutIsVisible1 =true},
                new NewArrivalModel{ NewArrivalImages ="SG",TitleName ="Foldable Practice Beam",Price="$219.00", Rating="4",StackLayoutIsVisible1 =true},
            };
        }
        public ICommand EditCommand => new Command(async (obj) =>
        {
            //var MyOrderMdl = obj as CartModel;
            await App.Current.MainPage.Navigation.PushModalAsync(new EditCartPage());
        });
        //public ICommand CartListCommand => new Command(async (obj) =>
        //{
        //	var MyOrderMdl = obj as MyOrderModel;
        //	App.Current.MainPage.Navigation.PushModalAsync(new EditCartPage(MyOrderMdl));
        //});
        public ICommand AddCartCommand => new Command(async (obj) =>
        {
            // var AddCardItem = obj as NewArrivalModel;
            await App.Current.MainPage.Navigation.PushModalAsync(new SaveAddressPage());
        });

        public ICommand GetQuoteCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new GetQuotePage());
        });
        public ICommand PaymentCommand => new Command(async (obj) =>
        {
            var item = _lastIncomplete.webUrl;
           // Settings.CheckoutId = string.Empty;
            await Browser.OpenAsync(item, BrowserLaunchMode.SystemPreferred);
            //await App.Current.MainPage.Navigation.PushModalAsync(new SaveAddressPage());
        });
        public ICommand MinusCommand => new Command<Node>(async (obj) =>
        {
            if (obj.quantity > 1)
            {
                obj.quantity--;
                await UpdateCart();
            }
        });
        public ICommand PlusCommand => new Command<Node>(async (obj) =>
        {
            obj.quantity++;
            await UpdateCart();
        });
       

        private async Task UpdateCart()
        {
            await ShowLoading();
            try
            {

                CartUpdateRequestModel request = new CartUpdateRequestModel
                {
                    checkoutId = Settings.CheckoutId
                };
                request.lineItems = new List<UpdateLineItem>();
                foreach (var item in CartList)
                {
                    request.lineItems.Add(new UpdateLineItem
                    {
                        id = item.id,
                        quantity = item.quantity,
                        variantId = item.variant.id
                    });
                }

                string query = @"mutation checkoutLineItemsUpdate($checkoutId: ID!, $lineItems: [CheckoutLineItemUpdateInput!]!) {
                  checkoutLineItemsUpdate(checkoutId: $checkoutId, lineItems: $lineItems) {
                    checkout {
                      id
                    }
                    checkoutUserErrors {
                      code
                      field
                      message
                    }
                  }
                }";
                var result = await _apiService.UpdateCart(query, request);
                if (result != null)
                {
                    await InitilizeData();
                }
                else
                {
                    await HideLoading();
                }
            }
            catch (Exception ex)
            {
                await HideLoading();
            }
            await HideLoading();
        }

        public ICommand DeleteCommand => new Command<Node>(async (obj) =>
        {
            await DeleteCartItem(obj);
        });

        private async Task DeleteCartItem(Node obj)
        {
            await ShowLoading();
            try
            {

                CartDeleteRequestModel request = new CartDeleteRequestModel
                {
                    checkoutId = Settings.CheckoutId
                };
                request.lineItemIds = new List<string>();
                request.lineItemIds.Add(obj.id);

                string query = @"mutation checkoutLineItemsRemove($checkoutId: ID!, $lineItemIds: [ID!]!) {
                  checkoutLineItemsRemove(checkoutId: $checkoutId, lineItemIds: $lineItemIds) {
                    checkout {
                      id
                    }
                    checkoutUserErrors {
                      code
                      field
                      message
                    }
                  }
                }";
                var result = await _apiService.DeleteCart(query, request);
                if (result != null)
                {
                    await InitilizeData();
                }
                else
                {
                    await HideLoading();
                }
            }
            catch (Exception ex)
            {
                await HideLoading();
            }
            await HideLoading();
        }

        public async Task Total1()
        {
            double total = 0;
            int quantity = 0;
            List<Mycart> obj_list = new List<Mycart>();
            obj_list = await App.Database.GetCart();
            foreach (var item in obj_list)
            {
                total = total + Convert.ToDouble(item.Price) * Convert.ToInt32(item.quantity);
                quantity = quantity + item.quantity;
            }
            Total = total.ToString("0.00");
            Quantity = quantity;
        }

        public async Task<IList<Edges>> GetAddressInfor()
        {
            string accestoken = Convert.ToString(Settings.Customer_Access_Token);
            //string addressId = SettingExtension.AddressId;
            char quote = '"';
            string modifiedString = quote + accestoken + quote;
            string query = "{ customer(customerAccessToken: " + modifiedString + "){id firstName lastName email createdAt lastIncompleteCheckout{id createdAt webUrl lineItems(first: 5){ edges{ node{quantity id title variant{ id image{ id originalSrc}}}}}}addresses(first: 3){edges{ node{ id firstName lastName address1 address2 city company country zip province}}}orders(first: 3){edges{node{id orderNumber name email lineItems(first: 3){ edges{ node{quantity variant{ id image{ originalSrc}}}}}}}}}}";
            //string qury = "{ customer(customerAccessToken:" + modifiedString + "){ id email firstName lastName createdAt  addresses(first: 9){ edges{ node{ firstName lastName address1 address2 city company country zip } } } } }";
            var res1 = await _apiService.GetAddress(query);
            if (res1.data.customer.addresses.edges.Count > 0)
            {
                Settings.Customer_Email = res1.data.customer.email;
                Customer_Address customer_Address = new Customer_Address();
                customer_Address.firstName = res1.data.customer.addresses.edges[0].node.firstName;
                customer_Address.lastName = res1.data.customer.addresses.edges[0].node.lastName;
                customer_Address.address1 = res1.data.customer.addresses.edges[0].node.address1;
                customer_Address.address2 = res1.data.customer.addresses.edges[0].node.address2;
                customer_Address.company = res1.data.customer.addresses.edges[0].node.company;
                customer_Address.country = res1.data.customer.addresses.edges[0].node.country;
                customer_Address.zip = res1.data.customer.addresses.edges[0].node.zip;
                customer_Address.zip = res1.data.customer.addresses.edges[0].node.zip;
                customer_Address.zip = res1.data.customer.addresses.edges[0].node.zip;
                customer_Address.zip = res1.data.customer.addresses.edges[0].node.zip;
                //App.Locator.ShippingConfirmation.InitializeData(customer_Address);
                return res1.data.customer.addresses.edges;
            }
            else
            {
                await App.Current.MainPage.Navigation.PushModalAsync(new AddNewAddress());
                return null;
            }
        }
        private bool _IsViewVisible;

        public bool IsViewVisible
        {
            get { return _IsViewVisible; }
            set { _IsViewVisible = value;RaisePropertyChanged(nameof(IsViewVisible)); }
        }


        public async Task InitilizeData()
        {
            try
            {
                string accestoken = Convert.ToString(Settings.Customer_Access_Token);
                char quote = '"';
                string modifiedString = quote + accestoken + quote;
                string query = @"{customer(customerAccessToken:" + modifiedString +"){ id firstName lastName email phone createdAt lastIncompleteCheckout{id createdAt webUrl lineItems(first: 5){ edges{ node{quantity id title variant{ id price selectedOptions{name value}  image{ id originalSrc}}}}}}addresses(first: 3){edges{ node{ id firstName lastName address1 address2 city company country}}}orders(first: 3){edges{node{id orderNumber name email lineItems(first: 3){ edges{ node{quantity variant{ id image{ originalSrc}}}}}}}}}}";
                var result = await _apiService.GetCustomer(query);
                if (result != null)
                {
                    _lastIncomplete = result.data.customer.lastIncompleteCheckout;
                    CartList = new ObservableCollection<Node>();
                    foreach (var item in result.data.customer.lastIncompleteCheckout.lineItems.edges)
                    {
                        CartList.Add(item.node);
                    }

                }
                else
                {
                    CartList = new ObservableCollection<Node>();
                }
                CostSummary = CartList.Sum(s => Convert.ToDouble(s.variant.price) * s.quantity);
                ShippingPrice = 0;
                TotalQuantity = CartList.Count();
                TotalPrice = ShippingPrice + CostSummary;
                if (CartList.Count > 0)
                {
                    IsViewVisible = true;
                }
                else
                {
                    IsViewVisible = false;
                }
            }
            catch (Exception ex)
            {
                CostSummary = 0;
                ShippingPrice = 0;
                TotalPrice = 0;
            }
        }
    }
}
