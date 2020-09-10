using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SportDirect.Controls;
using SportDirect.iOS.Renderers;
using Foundation;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AppPicker), typeof(AppPickerRenderer))]
namespace SportDirect.iOS.Renderers
{
    public class AppPickerRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null || this.Element == null)
                return;
            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }
    }
}