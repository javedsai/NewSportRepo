using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace SportDirect.Areas.PopUp
{
    public partial class ZoomImagePopUp : PopupPage
    {
        public ZoomImagePopUp(Object obj)
        {
            var image = obj as String;
            InitializeComponent();
            this.BindingContext = App.Locator.ZoomImagePop;
            productImage.Source = image;
        }
    }
}
