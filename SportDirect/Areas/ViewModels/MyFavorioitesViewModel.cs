using SportDirect.Areas.Model;
using SportDirect.Areas.Views;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class MyFavoritesViewModel : BasePageViewModel
    { 
        private ObservableCollection<ProductViewModel> _myFavoritesList;
        public ObservableCollection<ProductViewModel> MyFavoritesList
        {
            get { return _myFavoritesList; }
            set { _myFavoritesList = value; RaisePropertyChanged(); }
        } 
        public MyFavoritesViewModel()
        {
            MyFavoritesList = GetMyFavoritesList();
            foreach (var item in MyFavoritesList)
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
        public ObservableCollection<ProductViewModel> GetMyFavoritesList()
        {
            return new ObservableCollection<ProductViewModel>()
            {
                new ProductViewModel{Image= "productview", Favorite= "sharegrey", Title="Aluminum bench de joueurs",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel", Favorite = "sharegrey", Title ="Ice Divider board",Rating="5",Price="$119995.00" },
                new ProductViewModel{Image= "productview",Favorite= "sharegrey", Title="Aluminum bench de joueurs",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel",Favorite= "sharegrey", Title="Ice Divider board",Rating="5",Price="$119995.00" },
                new ProductViewModel{Image= "productview",Favorite= "sharegrey", Title="Aluminum bench de joueurs",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel",Favorite= "sharegrey", Title="Aluminum bench de joueurs",Rating="5",Price="$119995.00" },
                new ProductViewModel{Image= "productview",Favorite= "sharegrey", Title="Ice Divider board",Rating="4",Price="$429.95" },
                new ProductViewModel{Image= "divider_panel", Favorite= "sharegrey",Title="Aluminum bench de joueurs",Rating="5",Price="$119995.00" },
            };
        }
        
        public ICommand EditCommand => new Command(async (obj) =>
        {
            await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
        }); 
        public ICommand ShareCommand => new Command(async (obj) =>
        {
            var SendData = obj as ProductViewModel;
            if(SendData!=null)
                await Share.RequestAsync(SendData.Title);
            else
            {
                return;
            }
        });
    }
}    