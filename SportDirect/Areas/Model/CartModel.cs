using Acr.UserDialogs;
using SkiaSharp;
using SportDirect.Areas.ViewModels;
using SportDirect.Assets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.Model
{
    public class CartModel : BindableObject
    {
        private int _counter;
        public int Counter
        {
            get { return _counter; }
            set { _counter = value; OnPropertyChanged(); }
        }
        public ICommand MinusCommand => new Command(async (obj) =>
        {
            UserDialogs.Instance.ShowLoading();
            var obj2 = obj as CartModel;
            List<Mycart> obj_list = new List<Mycart>();
            obj_list = await App.Database.GetCart();
            obj_list = obj_list.Where(x => x.VariantId == obj2.variant_Id).ToList();
            Mycart mycart = new Mycart();
            if (Counter > 1)
            {
                Counter--;

                if (obj_list.Count > 0)
                {
                    mycart.Id = obj_list[0].Id;
                    mycart.VariantId = obj2.variant_Id;
                    mycart.quantity = Counter;
                    mycart.Price = obj2.Price;
                    mycart.ProductID = obj2.ProductID;
                    mycart.TitleName = obj2.TitleName;
                    mycart.ImageUrl = obj_list[0].NewArrivalImages;
                }
                await App.Database.SaveCart(mycart);
                await App.Locator.CartPage.Total1();
                //await Total();
            }
            else
            {
                mycart.Id = obj_list[0].Id;
                mycart.VariantId = obj2.variant_Id;
                mycart.quantity = Counter;
                mycart.Price = obj2.Price;
                mycart.ProductID = obj2.ProductID;
                mycart.TitleName = obj2.TitleName;
                mycart.ImageUrl = obj2.NewArrivalImages;
                await App.Database.DeleteCart(mycart);
                App.Locator.CartPage.Init();
            }
            UserDialogs.Instance.HideLoading();
        });
        public ICommand PlusCommand => new Command(async (obj) =>
        {
            //Counter++;
            Counter++;
            UserDialogs.Instance.ShowLoading();
            var obj2 = obj as CartModel;
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
                mycart.ImageUrl = obj_list[0].NewArrivalImages;
                mycart.NewArrivalImages = obj_list[0].NewArrivalImages;
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
                mycart.ImageUrl = obj2.NewArrivalImages;
                mycart.NewArrivalImages = obj2.NewArrivalImages;
            }
            await App.Database.SaveCart(mycart);
            await App.Locator.CartPage.Total1();
            UserDialogs.Instance.HideLoading();
        });
        public string Image { get; set; }
        public string Title { get; set; }
        public string ProductColor { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string MinusImage { get; set; }
        public string PlusImage { get; set; }
        public long variant_Id { get; set; }
        public string ProductID { get; set; }
        public string TitleName { get; set; }
        public string NewArrivalImages { get; set; }

    }
}
