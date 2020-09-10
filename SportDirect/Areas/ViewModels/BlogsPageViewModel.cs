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
	public class BlogsPageViewModel : BasePageViewModel
	{
		//SportDirect.Data.Models.Response.Data Data = (SportDirect.Data.Models.Response.Data)Application.Current.Properties["Data"];
		private ObservableCollection<BlogsModel> _blogsList;
		public ObservableCollection<BlogsModel> BlogsList
		{
			get { return _blogsList; }
			set { _blogsList = value; RaisePropertyChanged(); }
		} 

		public BlogsPageViewModel()
		{ 
			BlogsList = GetBlogsList();
		}
		
		public ObservableCollection<BlogsModel> GetBlogsList()
		{
			return new ObservableCollection<BlogsModel>()
			{
				new BlogsModel { Images="tennisnet",Title="What to do as exercises when you are locked up at home?", Date="March 19, 2020", DateImage="time",Comment="1 COMMENT", CommentImage="COMMENT", Descreptions="Like most people, we imagine that you are at home going around in circles,Like most people, we imagine that you are at home going around in circles,"},
				new BlogsModel { Images="tennisnet",Title="What to do as exercises when you are locked up at home?", Date="March 19, 2020",DateImage="time",Comment="2 COMMENT", CommentImage="COMMENT", Descreptions="Like most people, we imagine that you are at home going around in circles,Like most people, we imagine that you are at home going around in circles,"},
				new BlogsModel { Images="thumbnail_foam",Title="What to do as exercises when you are locked up at home?", Date="June 15, 2020",DateImage="time",Comment="1 COMMENT", CommentImage="COMMENT", Descreptions="we imagine that you are at home going around in circles"},
				new BlogsModel { Images="tennisnet",Title="What to do as exercises when you are locked up at home?", Date="May 19, 2020",DateImage="time",Comment="5 COMMENT", CommentImage="COMMENT", Descreptions="Like most people, we imagine that you are at home going around in circles,Like most people, we imagine that you are at home going around in circles,"},
				new BlogsModel { Images="tennisnet",Title="What to do as exercises when you are locked up at home?", Date="March 19, 2020",DateImage="time",Comment="1 COMMENT", CommentImage="COMMENT", Descreptions="Like most people, we imagine that you are at home going around in circles,Like most people, we imagine that you are at home going around in circles,"},
				new BlogsModel { Images="thumbnail_foam",Title="What to do as exercises when you are locked up at home?", Date="March 19, 2020",DateImage="time",Comment="1 COMMENT", CommentImage="COMMENT", Descreptions="Like most people, we imagine that you are at home going around in circles,Like most people, we imagine that you are at home going around in circles,"},
			};
		}

		public ICommand ReadMoreCommand => new Command(async (obj) =>
		{
			//var Blogsmdl = obj as Data.Models.Response.NewsModel;
			var Blogsmdl = obj as BlogsModel;
			await App.Current.MainPage.Navigation.PushModalAsync(new BlogsDetailsPage(Blogsmdl));
		});		
	}
}