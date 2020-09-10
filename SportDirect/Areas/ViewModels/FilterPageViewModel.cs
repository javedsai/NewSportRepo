using Acr.UserDialogs;
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
   public class FilterPageViewModel : BasePageViewModel
    {
        private string _imageAtoZ= "CheckGreen";
        public string ImageAtoZ
        {
            get => _imageAtoZ; 
            set { _imageAtoZ = value; RaisePropertyChanged(); }
        }
        private string _imageZtoA = "Uncheck";
        public string ImageZtoA
        {
            get=> _imageZtoA; 
            set { _imageZtoA = value; RaisePropertyChanged(); }
        }
        private string _imageHighToLow = "Uncheck";
        public string ImageHighToLow
        {
            get=> _imageHighToLow; 
            set { _imageHighToLow = value; RaisePropertyChanged(); }
        }
        private string _imageLowToHigh = "Uncheck";
        public string ImageLowToHigh
        {
            get=> _imageLowToHigh; 
            set { _imageLowToHigh = value; RaisePropertyChanged(); }
        }
        private string _imageMostToOld = "Uncheck";
        public string ImageMostToOld
        {
            get=> _imageMostToOld; 
            set { _imageMostToOld = value; RaisePropertyChanged(); }
        }
        private string _imageOldToMost = "Uncheck";
        public string ImageOldToMost
        {
            get=> _imageOldToMost; 
            set { _imageOldToMost = value; RaisePropertyChanged(); }
        }
         public ICommand AtoZCommand => new Command(async (obj) =>
         {
             ImageAtoZ = "CheckGreen";
             ImageZtoA = "Uncheck";
             ImageHighToLow = "Uncheck";
             ImageLowToHigh = "Uncheck";
             ImageMostToOld = "Uncheck";
             ImageOldToMost = "Uncheck";
         });
         public ICommand ZtoACommand => new Command(async (obj) =>
         {
             ImageAtoZ = "Uncheck";
             ImageZtoA = "CheckGreen";
             ImageHighToLow = "Uncheck";
             ImageLowToHigh = "Uncheck";
             ImageMostToOld = "Uncheck";
             ImageOldToMost = "Uncheck";

         });
         public ICommand HighToLowCommand => new Command(async (obj) =>
         {
             ImageAtoZ = "Uncheck";
             ImageZtoA = "Uncheck";
             ImageHighToLow = "CheckGreen";
             ImageLowToHigh = "Uncheck";
             ImageMostToOld = "Uncheck";
             ImageOldToMost = "Uncheck";
         });
         public ICommand LowToHighCommand => new Command(async (obj) =>
         {
             ImageAtoZ = "Uncheck";
             ImageZtoA = "Uncheck";
             ImageHighToLow = "Uncheck";
             ImageLowToHigh = "CheckGreen";
             ImageMostToOld = "Uncheck";
             ImageOldToMost = "Uncheck";
         });
         public ICommand MostToOldCommand => new Command(async (obj) =>
         {
             ImageAtoZ = "Uncheck";
             ImageZtoA = "Uncheck";
             ImageHighToLow = "Uncheck";
             ImageLowToHigh = "Uncheck";
             ImageMostToOld = "CheckGreen";
             ImageOldToMost = "Uncheck";
         });
         public ICommand OldToMostCommand => new Command(async (obj) =>
         {
             ImageAtoZ = "Uncheck";
             ImageZtoA = "Uncheck";
             ImageHighToLow = "Uncheck";
             ImageLowToHigh = "Uncheck";
             ImageMostToOld = "Uncheck";
             ImageOldToMost = "CheckGreen";
         });

        public FilterPageViewModel()
        {
            FilterList = GetFilterList();
        }
        private ObservableCollection<CustomerModel> _filterList;
        public ObservableCollection<CustomerModel> FilterList
        {
            get { return _filterList; }
            set { _filterList = value; RaisePropertyChanged(); }
        } 
        public ObservableCollection<CustomerModel> GetFilterList()
        {   return new ObservableCollection<CustomerModel>()
            {
                new CustomerModel{ CategoriesTitle="All Products",FrameColor="Red" },
                new CustomerModel{ CategoriesTitle="New Products",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Pear Baloon",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Players Bench",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Protective Padding",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Windscreen",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Pear Baloon",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Players Bench",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Protective Padding",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Windscreen",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Pear Baloon",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Players Bench",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Protective Padding",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Windscreen",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Pear Baloon",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Players Bench",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Protective Padding",FrameColor="Gray" },
                new CustomerModel{ CategoriesTitle="Windscreen",FrameColor="Gray" },                
            };
        } 
        public Command ResetCommand
        {
            get
            {
                return new Command(async () =>
                {
                    UserDialogs.Instance.Alert("Coming Soon");
                    //await App.Current.MainPage.Navigation.PushModalAsync(new ProductViewPage());
                });
            }
        }
        public Command ApplyFilterCommand
        {
            get
            {
                return new Command(async () =>
                {
                    await App.Current.MainPage.Navigation.PushModalAsync(new ProductViewPage());
                });
            }
        }
    }
}