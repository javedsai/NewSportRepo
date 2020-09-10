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
    public class FAQsPageViewModel : BasePageViewModel
    {
		private ObservableCollection<NewsModel> _fAQsList;
		public ObservableCollection<NewsModel> FAQsList
		{
			get { return _fAQsList; }
			set { _fAQsList = value; RaisePropertyChanged(); }
		}

		public FAQsPageViewModel()
		{
			FAQsList = GetFAQsList();
		} 
		public ObservableCollection<NewsModel> GetFAQsList()
		{
			return new ObservableCollection<NewsModel>()
			{
				new NewsModel { Title="Loream ipsum?", Descreptions="Lorem ipsum is simple dummy text of the printing. The FAQ has become an important component of websites, either as a stand-alone page or as a website section with multiple subpages per question or topic."} , 
				new NewsModel { Title="Loream ipsum is simply?", Descreptions="Lorem ipsum is simple dummy text of the printing, Embedded links to FAQ pages have become commonplace in website navigation bars, bodies, or footers dummy text of the printing The FAQ has become an important component of websites."} , 
			    new NewsModel { Title="Loream ipsum is simply?", Descreptions="Lorem ipsum is simple dummy text of the printing. The FAQ has become an important component of websites, either as a stand-alone page or as a website section with multiple subpages per question or topic."} , 
				new NewsModel { Title="Loream ipsum is simply?", Descreptions="Lorem ipsum is simple dummy text of the printing, Embedded links to FAQ pages have become commonplace in website navigation bars, bodies, or footers dummy text of the printing The FAQ has become an important component of websites."} , 
			    new NewsModel { Title="Loream ipsum is simply?", Descreptions="Lorem ipsum is simple dummy text of the printing. The FAQ has become an important component of websites, either as a stand-alone page or as a website section with multiple subpages per question or topic."} , 
				new NewsModel { Title="Loream ipsum is simply?", Descreptions="Lorem ipsum is simple dummy text of the printing, Embedded links to FAQ pages have become commonplace in website navigation bars, bodies, or footers dummy text of the printing The FAQ has become an important component of websites."} , 
			    new NewsModel { Title="Loream ipsum is simply?", Descreptions="Lorem ipsum is simple dummy text of the printing. The FAQ has become an important component of websites, either as a stand-alone page or as a website section with multiple subpages per question or topic."} , 
				new NewsModel { Title="Loream ipsum is simply?", Descreptions="Lorem ipsum is simple dummy text of the printing, Embedded links to FAQ pages have become commonplace in website navigation bars, bodies, or footers dummy text of the printing The FAQ has become an important component of websites."} , 
			 };
		}

		public ICommand BookInstallationCommand => new Command(async (obj) =>
		{
			//var Newsmdl = obj as Data.Models.Response.NewsModel;
			//var Newsmdl = obj as NewsModel;
			//await App.Current.MainPage.Navigation.PushModalAsync(new NewsDetailsPage(Newsmdl));
		});
	}
}     