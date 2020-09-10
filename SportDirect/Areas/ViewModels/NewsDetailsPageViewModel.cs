using GalaSoft.MvvmLight.Views;
using SportDirect.Areas.Model;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
   public class NewsDetailsPageViewModel :BasePageViewModel
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value;RaisePropertyChanged(); }
        }
        private string image;
        public string Image
        {
            get { return image; }
            set { image = value;RaisePropertyChanged(); }
        }
        private string _date;
        private INavigationService _navigationService;

        public string Date
        {
            get { return _date; }
            set { _date = value;RaisePropertyChanged(); }
        }

        private string _details;
        public string Details
        {
            get { return _details; }
            set { _details = value;RaisePropertyChanged(); }
        }

        private string _descreptions;
        public string Descreptions
        {
            get { return _descreptions; }
            set { _descreptions = value;RaisePropertyChanged(); }
        }

        public NewsDetailsPageViewModel( )
        {
            Details = "The fabrics are provided with small spaces which let filter a little wind and light. This avoids putting too much pressure on the fences and provides players with minimal ventilation. ventilation holes can also be added normally every 10 feet, especially on 9 feet high canvases and / or wind is often an important factor. The canvases are easy to install using ty-wraps through the eyelets positioned at the perimeter and in the center in the case of 9-foot canvases. Reinforcements under the eyelets prevent tearing and extend the life of the fabrics.";
        }
        public ICommand GetBackCommand => new Command(async () =>
        {
            await App.Current.MainPage.Navigation.PopModalAsync();
        });

        internal void Init(NewsModel newsmdl)
        {
            Title = newsmdl.Title;
            Image = newsmdl.Images;
            Date = newsmdl.Date;
            Descreptions = newsmdl.Descreptions;
        }
    }
}