using Acr.UserDialogs;
using Plugin.Media;
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
    public class EditMyReviewsPageViewModel :BasePageViewModel
    {
        private string image;
        public string Image
        {
            get { return image; }
            set { image = value; RaisePropertyChanged(); }
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
            set { _productColor = value; RaisePropertyChanged(); }
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
            set { _frameColor = value; RaisePropertyChanged(); }
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
            set { _review = value; RaisePropertyChanged(); }
        }
        private ImageSource _profilePick;
        public ImageSource ProfilePick
        {
            get { return _profilePick; }
            set { _profilePick = value; RaisePropertyChanged(); }
        }
        private string _descraptions;
        public string Descraptions
        {
            get { return _descraptions; }
            set { _descraptions = value;RaisePropertyChanged(); }
        }
        private string _star1;
        public string star1
        {
            get { return _star1; }
            set { _star1 = value;RaisePropertyChanged(); }
        }
        private string _star2;
        public string star2
        {
            get { return _star2; }
            set { _star2 = value;RaisePropertyChanged(); }
        }
        private string _star3;
        public string star3
        {
            get { return _star3; }
            set { _star3 = value;RaisePropertyChanged(); }
        }
        private string _star4;
        public string star4
        {
            get { return _star4; }
            set { _star4 = value;RaisePropertyChanged(); }
        }
        private string _star5;
        public string star5
        {
            get { return _star5; }
            set { _star5 = value;RaisePropertyChanged(); }
        }

        public EditMyReviewsPageViewModel()
        {
            //MyOrderList = GetMyOrderList();
        }
        internal void Init(MyOrderModel editMyOrderMdl)
        {
            Image = editMyOrderMdl.Image;
            Title = editMyOrderMdl.Title;
            ProductColor = editMyOrderMdl.ProductColor;
            Price = editMyOrderMdl.Price;
            Review = editMyOrderMdl.Descraptions;
            if (int.Parse(editMyOrderMdl.Rating) == 3)
            {
                star1 = "star";
                star2 = "star";
                star3 = "star";
                star4 = "unfilledStar";
                star5 = "unfilledStar";
            }
            else if (int.Parse(editMyOrderMdl.Rating) == 4)
            {
                star1 = "star";
                star2 = "star";
                star3 = "star";
                star4 = "star";
                star5 = "unfilledStar";
            }
            else if (int.Parse(editMyOrderMdl.Rating) == 5)
            {
                star1 = "star";
                star2 = "star";
                star3 = "star";
                star4 = "star";
                star5 = "star";
            }
        }
        private ObservableCollection<ProfilePickModel> _myOrderList;
        public ObservableCollection<ProfilePickModel> MyOrderList
        {
            get { return _myOrderList; }
            set { _myOrderList = value; RaisePropertyChanged(); }
        }         

        //public ObservableCollection<MyOrderModel> GetMyOrderList()
        //{
        //    return new ObservableCollection<MyOrderModel>()
        //    {
        //        new MyOrderModel {  },
        //        new MyOrderModel  { }
        //        //new MyOrderModel {Image="thumbnail_foam" },
        //        //new MyOrderModel {Image="thumbnail_foam" }, 
        //    };
        //}
        public ICommand EditCommand => new Command(async (obj) =>
        {
           // await App.Current.MainPage.Navigation.PopModalAsync();           
        });
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
                ObservableCollection<ProfilePickModel> imageList = new ObservableCollection<ProfilePickModel>();
                await CrossMedia.Current.Initialize();
                var file = await CrossMedia.Current.PickPhotoAsync();
                if (file != null)
                { 
                    //ProfilePick = file.Path;
                   //var ProfilePick = ImageSource.FromStream(() =>
                   // {
                   //     var stream = file.GetStream();
                   //     return stream;
                   // });
                    ProfilePickModel data = new ProfilePickModel();
                    data.ProfileImage = file.Path;                     
                    imageList.Add(data);
                    MyOrderList = imageList;                   
                }
                else
                {
                    UserDialogs.Instance.Alert("Picking a photo is not supported", "No upload", "Ok");
                    return;
                }
              
            }
            catch (Exception ex)
            {
                UserDialogs.Instance.Alert(ex.ToString(), "Error", "OK");
            }
        });
    }
}