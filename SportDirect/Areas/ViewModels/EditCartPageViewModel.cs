using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class EditCartPageViewModel: BasePageViewModel
    {
		private ObservableCollection<CartModel> _editcartList;
		public ObservableCollection<CartModel> EditCartList
		{
			get { return _editcartList; }
			set { _editcartList = value; RaisePropertyChanged(); }
		}
		private string _pONumber;
		public string PONumber
		{
			get { return _pONumber; }
			set { _pONumber = value; RaisePropertyChanged(); }
		}

		public EditCartPageViewModel()
		{
			EditCartList = GetEditCartList();
		}

		public ObservableCollection<CartModel> GetEditCartList()
		{
			return new ObservableCollection<CartModel>()
			{
				new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
				new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
				new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
				new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
                new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Qty="Qty: 1",Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
				new CartModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)",Qty="Qty: 1", Price="$219.00",  MinusImage ="Minus",PlusImage ="Plus",Counter=1, },
		  };
		}
		public ICommand DoneCommand => new Command(async (obj) =>
		{
			App.Current.MainPage.Navigation.PopModalAsync();
		});
		 public ICommand DeleteCommand => new Command(async (obj) =>
		 { 
			 var cartdelMdl = obj as CartModel;
			 EditCartList.Remove(cartdelMdl);
		 });
		public ICommand EditPaymentCommand => new Command(async (obj) =>
		{
			App.Current.MainPage.Navigation.PushModalAsync(new SaveAddressPage());
		});
	}
} 