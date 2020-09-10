using Acr.UserDialogs;
using Plugin.Media;
using SportDirect.Areas.Model;
using SportDirect.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.ViewModels
{
    public class MyOrderDetailsPageViewModel : BasePageViewModel
    {
        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
        }
        private string _orderDate;
        public string OrderDate
        {
            get { return _orderDate; }
            set { _orderDate = value; RaisePropertyChanged(); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { _title = value; RaisePropertyChanged(); }
        }
        private string _productColor;
        public string ProductColor
        {
            get { return _productColor; }
            set { _productColor = value;RaisePropertyChanged(); }
        }
        private string _price;
        public string Price
        {
            get { return _price; }
            set { _price = value; RaisePropertyChanged(); }
        }
        private string _frameColor;
        public string FrameColor
        {
            get { return _frameColor; }
            set { _frameColor = value;RaisePropertyChanged(); }
        }
        private string _orderStatus;
        public string OrderStatus
        {
            get { return _orderStatus; }
            set { _orderStatus = value; RaisePropertyChanged(); }
        }
        private string _review;
        public string Review
        {
            get { return _review; }
            set { _review = value;RaisePropertyChanged(); }
        }
        private ImageSource _profilePick;
        public ImageSource ProfilePick
        {
            get { return _profilePick; }
            set { _profilePick = value;RaisePropertyChanged(); }
        }

        public MyOrderDetailsPageViewModel()
        {
         
        }
        internal void Init(MyOrderModel myOrderMdl)
        {
            Image = myOrderMdl.Image;  
            OrderDate = myOrderMdl.OrderDate;  
            Title = myOrderMdl.Title;  
            ProductColor = myOrderMdl.ProductColor;  
            Price = myOrderMdl.Price;  
            FrameColor = myOrderMdl.FrameColor;  
            OrderStatus = myOrderMdl.OrderStatus;  
        }
        public ICommand PublishCommand => new Command(async (obj) =>
        {
            if (string.IsNullOrEmpty(Review))
            {
                UserDialogs.Instance.Alert("Please enter the review.");
                return;
            }
            else
            {
                UserDialogs.Instance.ShowLoading();
                await App.Current.MainPage.Navigation.PopModalAsync();
                UserDialogs.Instance.HideLoading();
                Review = string.Empty;
            }
          
        });
        public ICommand AddPicturesCommand => new Command(async (obj) =>
        {
            try
            {
                if (!CrossMedia.Current.IsPickPhotoSupported)
                {
                    UserDialogs.Instance.Alert("no upload", "picking a photo is not supported", "ok");
                    return;
                }

                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                    return;

                ProfilePick = ImageSource.FromStream(() => file.GetStream());
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.Message);
            }
        });
    }
}