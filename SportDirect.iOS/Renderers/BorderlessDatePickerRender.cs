using ClassBuzzApp.iOS.Renderers;
using SportDirect.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(BorderlessDatePicker), typeof(BorderlessDatePickerRender))]
namespace ClassBuzzApp.iOS.Renderers
{
    public class BorderlessDatePickerRender : DatePickerRenderer
    {
         protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
         {
             base.OnElementChanged(e);
             if (this.Control == null)
                 return;
             var element = e.NewElement as BorderlessDatePicker;
             if (!string.IsNullOrWhiteSpace(element.Placeholder))
             {
                 Control.Text = element.Placeholder;
             }
             Control.BorderStyle = UITextBorderStyle.RoundedRect;
           // Control.Layer.BorderColor = UIColor.From#533f95.CGColor;   
            //Control.Layer.CornerRadius = 10;
             //Control.Layer.BorderWidth = 1f;
             //Control.AdjustsFontSizeToFitWidth = true;
             //Control.TextColor = UIColor.From#533f95;   
         
                Control.ShouldEndEditing += (textField) => {
                var seletedDate = (UITextField)textField;
                var text = seletedDate.Text;
                if (text == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
                return true;
            };
         }
    }
}