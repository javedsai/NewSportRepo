using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SportDirect.Areas.Model
{
   public class ProductViewModel : BindableObject
    {
        public string Image { get; set; }
        public string Title { get; set; }
        public string Price { get; set; }
        public string Product_Id { get; set; }
        public string Rating { get; set; }
        public string Favorite { get; set; }
        public string star1 { get; set; }
        public string star2 { get; set; }
        public string star3 { get; set; }
        public string star4 { get; set; }
        public string star5 { get; set; }             
    }
}
