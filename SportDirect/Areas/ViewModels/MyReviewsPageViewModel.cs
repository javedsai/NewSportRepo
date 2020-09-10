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
   public class MyReviewsPageViewModel :BasePageViewModel
    {
		private ObservableCollection<MyOrderModel> _myOrderList;
		public ObservableCollection<MyOrderModel> MyOrderList
		{
			get { return _myOrderList; }
			set { _myOrderList = value; RaisePropertyChanged(); }
		}

		public MyReviewsPageViewModel()
		{
			MyOrderList = GetMyOrderList();

            foreach (var item in MyOrderList)
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

		public ObservableCollection<MyOrderModel> GetMyOrderList()
		{
			return new ObservableCollection<MyOrderModel>()
			{
				new MyOrderModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00", Rating="4", Descraptions="Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo" },
				new MyOrderModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00", Rating="4", Descraptions="Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo" },
				new MyOrderModel {Image="tennisnet", Title="Practice Beam",      ProductColor="8x8'' 16 feet(Blue)", Price="$888.00", Rating="3", Descraptions="invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo" },
				new MyOrderModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00", Rating="4", Descraptions="Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo" },
				new MyOrderModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Green)", Price="$419.00", Rating="4", Descraptions="Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo" },
				new MyOrderModel {Image="tennisnet", Title="Reviews Details",    ProductColor="4x4'' 8 feet (Blue)", Price="$519.00", Rating="5", Descraptions="Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo" },
				new MyOrderModel {Image="thumbnail_foam", Title="Practice Beam", ProductColor="4x6'' 8 feet (Blue)", Price="$219.00", Rating="4", Descraptions="Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo" },
			};
		}

		public ICommand EditCommand => new Command(async (obj) =>
		{
			var EditMyOrderMdl = obj as MyOrderModel;
		    await App.Current.MainPage.Navigation.PushModalAsync(new EditMyReviewsPage(EditMyOrderMdl));
		});
	}
}