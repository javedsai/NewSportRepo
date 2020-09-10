using SportDirect.Assets;
using SportDirect.Data.Models.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;

using Acr.UserDialogs;
using SportDirect.Areas.Views;

namespace SportDirect.Areas.Model
{
    public class NewArrivalModel : BindableObject
    {
        private int _counter;
        public int Counter
        {
            get { return _counter; }
            set { _counter = value; OnPropertyChanged(); }
        }
        private bool _stackLayoutIsVisible;
        public bool StackLayoutIsVisible
        {
            get { return _stackLayoutIsVisible; }
            set { _stackLayoutIsVisible = value; OnPropertyChanged(); }
        }
        private bool _stackLayoutIsVisible1;
        public bool StackLayoutIsVisible1
        {
            get { return _stackLayoutIsVisible1; }
            set { _stackLayoutIsVisible1 = value; OnPropertyChanged(); }
        }
        public ICommand MinusCommand => new Command((obj) =>
       {
           if (Counter > 1)
           {
               Counter--;
           }
       });
        public ICommand PlusCommand => new Command(async (obj) =>
      {
          Counter++;
          var obj2 = obj as NewArrivalModel;
          List<Mycart> obj_list = new List<Mycart>();
          obj_list = await App.Database.GetCart();
          obj_list = obj_list.Where(x => x.VariantId == obj2.variant_Id).ToList();
          Mycart mycart = new Mycart();
          if (obj_list.Count > 0)
          {
              mycart.Id = obj_list[0].Id;
              mycart.VariantId = obj2.variant_Id;
              mycart.quantity = Counter;
              mycart.Price = obj2.Price;
              mycart.ProductID = obj2.ProductID;
              mycart.TitleName = obj2.TitleName;
              mycart.NewArrivalImages = obj2.NewArrivalImages;
          }
          else
          {
              //Mycart mycart = new Mycart();
              mycart.Id = 0;
              mycart.VariantId = obj2.variant_Id;
              mycart.quantity = 1;
              mycart.Price = obj2.Price;
              mycart.ProductID = obj2.ProductID;
              mycart.TitleName = obj2.TitleName;
              mycart.NewArrivalImages = obj2.NewArrivalImages;
          }
          await App.Database.SaveCart(mycart);
      });
        public ICommand AddCartCommand => new Command(async (obj) =>
       {
           //StackLayoutIsVisible1 = false;
           //StackLayoutIsVisible = true;
           UserDialogs.Instance.ShowLoading();
           // var AddCardItem = obj as NewArrivalModel;
           NewArrivalModel obj_modal = new NewArrivalModel();
           //obj_modal.StackLayoutIsVisible1 = false;
           //obj_modal.StackLayoutIsVisible = true;
           var obj2 = obj as NewArrivalModel;
           List<Mycart> obj_list = new List<Mycart>();
           obj_list = await App.Database.GetCart();
           obj_list = obj_list.Where(x => x.VariantId == obj2.variant_Id).ToList();
           Mycart mycart = new Mycart();
           if (obj_list.Count > 0)
           {
               mycart.Id = obj_list[0].Id;
               mycart.VariantId = obj2.variant_Id;
               mycart.quantity = obj_list[0].quantity + 1;
               mycart.Price = obj2.Price;
               mycart.ProductID = obj2.ProductID;
               mycart.TitleName = obj2.TitleName;
               mycart.NewArrivalImages = obj2.NewArrivalImages;
               Counter = obj_list[0].quantity + 1;
           }
           else
           {
               //Mycart mycart = new Mycart();
               mycart.Id = 0;
               mycart.VariantId = obj2.variant_Id;
               mycart.quantity = 1;
               mycart.Price = obj2.Price;
               mycart.ProductID = obj2.ProductID;
               mycart.TitleName = obj2.TitleName;
               mycart.NewArrivalImages = obj2.NewArrivalImages;
               Counter = 1;
           }
           await App.Database.SaveCart(mycart);
           UserDialogs.Instance.HideLoading();
           await App.Current.MainPage.Navigation.PushModalAsync(new CartPage());
          
       });
        public string NewArrivalImages { get; set; }
        public string MinusImage { get; set; }
        public long variant_Id { get; set; }
        public string PlusImage { get; set; }
        public string TitleName { get; set; }
        public string Rating { get; set; }
        public string AddProduct { get; set; }
        public string Price { get; set; }
        public string ProductID { get; set; }
        public string star1 { get; set; }
        public string star2 { get; set; }
        public string star3 { get; set; }
        public string star4 { get; set; }
        public string star5 { get; set; }
        public string body_html { get; set; }
        //public IList<Images> images { get; set; }
        public Image image { get; set; }
        //public IList<Variants> variants { get; set; }
    }
}
