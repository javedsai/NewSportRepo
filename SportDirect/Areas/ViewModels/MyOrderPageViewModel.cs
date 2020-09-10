using Acr.UserDialogs;
using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class MyOrderPageViewModel :BasePageViewModel
    {
		private ObservableCollection<MyOrderModel> _myOrderList;
		public ObservableCollection<MyOrderModel> MyOrderList
		{
			get { return _myOrderList; }
			set { _myOrderList = value;RaisePropertyChanged(); }
		}
		private Color _orderTextColor=Color.FromHex("#267EAA");
		public Color OrderTextColor
		{
			get => _orderTextColor; 
			set { _orderTextColor = value; RaisePropertyChanged(); }
		}

		private Color _orderBoxviewColor=Color.FromHex("#267EAA");
		public Color OrderBoxviewColor
		{
			get=> _orderBoxviewColor;
			set { _orderBoxviewColor = value; RaisePropertyChanged(); }
		}
		private Color _quotesTextColor=Color.Black;
		public Color QuotesTextColor
		{
			get =>_quotesTextColor; 
			set { _quotesTextColor = value; RaisePropertyChanged(); }
		}

		private Color _quotesBoxviewColor = Color.WhiteSmoke;
		public Color QuotesBoxviewColor
		{
			get=> _quotesBoxviewColor;
			set { _quotesBoxviewColor = value; RaisePropertyChanged(); }
		}

		private bool _collectionViewIsVisible=true;
		public bool CollectionViewIsVisible
		{
			get { return _collectionViewIsVisible; }
			set { _collectionViewIsVisible = value; RaisePropertyChanged(); }
		} 
		public MyOrderPageViewModel()
		{
			//MyOrderList = GetMyOrderList();
		}

		public async Task GetMyOrderList()
		{


			//return new ObservableCollection<MyOrderModel>()
			//{
			//	new MyOrderModel {Image="thumbnail_foam",OrderDate="Order Date: 07 July 2020 09:00 am", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00",OrderStatus="Pickup" ,FrameColor="#0079FE" },
			//	new MyOrderModel {Image="thumbnail_foam",OrderDate="Order Date: 07 July 2020 09:00 am", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00",OrderStatus="Delivered" ,FrameColor="#42B986" },
		 //       new MyOrderModel {Image="thumbnail_foam",OrderDate="Order Date: 07 July 2020 09:00 am", Title="Practice Beam", ProductColor="4x6'' 8 feet (Red)", Price="$219.00",OrderStatus="Pickup" ,FrameColor="#0079FE" },
			//	new MyOrderModel {Image="tennisnet", OrderDate="Order Date: 07 July 2020 09:00 am" ,Title="product details", ProductColor="6x4 16'' feet(Blue)", Price="$519.00",OrderStatus="Delivered" ,FrameColor="#42B986" },
		 //       new MyOrderModel {Image="thumbnail_foam",OrderDate="Order Date: 07 July 2020 09:00 am", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00",OrderStatus="Pickup" ,FrameColor="#0079FE" },
			//	new MyOrderModel {Image="thumbnail_foam",OrderDate="Order Date: 07 July 2020 09:00 am", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00",OrderStatus="Delivered" ,FrameColor="#42B986" },
			//};
		}
	    public ICommand MyOrdersCommand => new Command(async (obj) =>
	    {
			CollectionViewIsVisible = false;
			UserDialogs.Instance.ShowLoading();
			await Task.Delay(500);		
			OrderTextColor = Color.FromHex("#267EAA");
			OrderBoxviewColor =Color.FromHex("#267EAA");
			QuotesTextColor = Color.Black;
			QuotesBoxviewColor = Color.WhiteSmoke;
			UserDialogs.Instance.HideLoading();
			CollectionViewIsVisible = true;
		});
	    public ICommand MyQuotesCommand => new Command(async (obj) =>
	    {
			CollectionViewIsVisible = false;
			UserDialogs.Instance.ShowLoading();
			await Task.Delay(500);				
			UserDialogs.Instance.ShowLoading();
			QuotesTextColor = Color.FromHex("#267EAA");
			QuotesBoxviewColor = Color.FromHex("#267EAA");
			OrderTextColor = Color.Black;
			OrderBoxviewColor = Color.WhiteSmoke;
			UserDialogs.Instance.HideLoading();
			CollectionViewIsVisible = true;
		});
	    public ICommand MyOrderCommand => new Command(async (obj) =>
	    {
	   	  var MyOrderMdl = obj as MyOrderModel;
	   	  App.Current.MainPage.Navigation.PushModalAsync(new MyOrderDetailsPage(MyOrderMdl));
	    });
	}
}