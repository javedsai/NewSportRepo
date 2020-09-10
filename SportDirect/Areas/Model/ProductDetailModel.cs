using SportDirect.Data.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SportDirect.Areas.Model
{
    public class ProductDetailModel : ViewModelBase
    {
        public string CarouselImages { get; set; }
        public string CategoriesImages { get; set; }
        public string CategoriesColor { get; set; }
        public string CategoriesName { get; set; }

        public string ProductImages { get; set; }
        public string ProductForwardImages { get; set; }
        public string productName { get; set; }
        public string Rating { get; set; }
        public string ProductPrice { get; set; }
        public string star1 { get; set; }
        public string star2 { get; set; }
        public string star3 { get; set; }
        public string star4 { get; set; }
        public string star5 { get; set; }

        //color
        public string FrameBgColor { get; set; }



        //SizeModel
        public string Size { get; set; }
        public string SizeTextColor { get; set; }
        //public string FrameBgColor { get; set; }

        private bool _isSelected;
        public bool IsSelected { get => _isSelected; set { _isSelected = value; OnPropertyChanged(); } }
        public Color _colorSelected;
        public Color ColorSelected
        {
            get => _colorSelected; set { _colorSelected = value; OnPropertyChanged(); }
        }
    }
}
