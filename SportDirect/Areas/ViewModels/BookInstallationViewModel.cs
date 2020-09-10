using SportDirect.Areas.Model;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class BookInstallationViewModel : BasePageViewModel
	{//SportDirect.Data.Models.Response.Data Data = (SportDirect.Data.Models.Response.Data)Application.Current.Properties["Data"];

		//public ObservableCollection<Data.Models.Response.News> NewsList { get; set; }
		private ObservableCollection<NewsModel> _bookInstallationList;
		public ObservableCollection<NewsModel> BookInstallationList
		{
			get { return _bookInstallationList; }
			set { _bookInstallationList = value; RaisePropertyChanged(); }
		}

		public BookInstallationViewModel()
		{
			BookInstallationList = GetBookInstallationList();
		}
		//public async void LoadNewsData()
		//{
		//	UserDialogs.Instance.ShowLoading();
		//	NewsList = new ObservableCollection<Data.Models.Response.News>(Data.news);
		//	RaisePropertyChanged(nameof(NewsList));
		//	UserDialogs.Instance.HideLoading();
		//}
		public ObservableCollection<NewsModel> GetBookInstallationList()
		{
			return new ObservableCollection<NewsModel>()
			{
				new NewsModel { Title="Netting installation"} ,
				new NewsModel { Title="Trampolines installation"} ,
				new NewsModel { Title="soccer goal installation"} ,
				new NewsModel { Title="hockey goal installation"} ,
				new NewsModel { Title="Basketball goal installation"} ,
				new NewsModel { Title="Hockey rinks installation"} ,
				new NewsModel { Title="Column pad and mats installation"} ,
				new NewsModel { Title="Column pad and mats installation"} 
				};
		}

		public ICommand FAQsCommand => new Command(async (obj) =>
		{
			//var Newsmdl = obj as Data.Models.Response.NewsModel;
			//var Newsmdl = obj as NewsModel;
			//await App.Current.MainPage.Navigation.PushModalAsync(new NewsDetailsPage(Newsmdl));
		});
	}
}