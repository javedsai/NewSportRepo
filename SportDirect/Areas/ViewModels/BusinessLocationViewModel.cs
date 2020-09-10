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
   public class BusinessLocationViewModel : BasePageViewModel
    {
		private ObservableCollection<NewsModel> _businessLocationList;
		public ObservableCollection<NewsModel> BusinessLocationList
		{
			get { return _businessLocationList; }
			set { _businessLocationList = value; RaisePropertyChanged(); }
		}

		public BusinessLocationViewModel()
		{
			BusinessLocationList = GetBusinessLocationList();
		} 
		public ObservableCollection<NewsModel> GetBusinessLocationList()
		{
			return new ObservableCollection<NewsModel>()
			{
				new NewsModel { Title="Country Name", Descreptions="9 glen Ridge Dr. Narwalk, CT 06851"},
				new NewsModel { Title="Country Name", Descreptions="9 glen Ridge Dr. Narwalk, CT 06851"},
				new NewsModel { Title="Country Name", Descreptions="9 glen Ridge Dr. Narwalk, CT 06851"},
				new NewsModel { Title="Country Name", Descreptions="9 glen Ridge Dr. Narwalk, CT 06851"},
				new NewsModel { Title="Country Name", Descreptions="9 glen Ridge Dr. Narwalk, CT 06851"},
				new NewsModel { Title="Country Name", Descreptions="9 glen Ridge Dr. Narwalk, CT 06851"},
				new NewsModel { Title="Country Name", Descreptions="9 glen Ridge Dr. Narwalk, CT 06851"},
			};
		}

		public ICommand ReadMoreCommand => new Command(async (obj) =>
		{
			//var Newsmdl = obj as Data.Models.Response.NewsModel;
			var Newsmdl = obj as NewsModel;
			//await App.Current.MainPage.Navigation.PushModalAsync(new NewsDetailsPage(Newsmdl));
		});
	}
} 
