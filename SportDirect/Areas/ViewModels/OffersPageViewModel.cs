using GalaSoft.MvvmLight.Views;
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
   public class OffersPageViewModel : BasePageViewModel
    {
		//SportDirect.Data.Models.Response.Data Data = (SportDirect.Data.Models.Response.Data)Application.Current.Properties["Data"];
		 
		//public ObservableCollection<Data.Models.Response.News> NewsList { get; set; }
		private ObservableCollection<NewsModel> _newsList;
		public ObservableCollection<NewsModel> NewsList
		{
			get { return _newsList; }
			set { _newsList = value; RaisePropertyChanged(); }
		}

		public OffersPageViewModel( )
		{ 
			NewsList = GetNewsList();
		}
		//public async void LoadNewsData()
		//{
		//	UserDialogs.Instance.ShowLoading();
		//	NewsList = new ObservableCollection<Data.Models.Response.News>(Data.news);
		//	RaisePropertyChanged(nameof(NewsList));
		//	UserDialogs.Instance.HideLoading();
		//}
		public ObservableCollection<NewsModel> GetNewsList()
		{
			return new ObservableCollection<NewsModel>()
			{
				new NewsModel { Images="offer2",Title="20 % off on All products for New User", Descreptions="PROMOCODE: NEWUSER20"},
				new NewsModel { Images="offer2",Title="20 % off on All products for New User", Descreptions="PROMOCODE: NEWUSER20"},
				new NewsModel { Images="offer2",Title="20 % off on All products for New User", Descreptions="PROMOCODE: NEWUSER20"},
				new NewsModel { Images="offer2",Title="20 % off on All products for New User", Descreptions="PROMOCODE: NEWUSER20"},
				new NewsModel { Images="offer2",Title="20 % off on All products for New User", Descreptions="PROMOCODE: NEWUSER20"},
				new NewsModel { Images="offer2",Title="20 % off on All products for New User", Descreptions="PROMOCODE: NEWUSER20"},
				};
		}

		public ICommand ReadMoreCommand => new Command(async (obj) =>
		{
			//var Newsmdl = obj as Data.Models.Response.NewsModel;
			//var Newsmdl = obj as NewsModel;
			//await App.Current.MainPage.Navigation.PushModalAsync(new NewsDetailsPage(Newsmdl));
		});
	}
}