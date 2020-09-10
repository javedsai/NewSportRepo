using SportDirect.Controls;
using SportDirect.Droid.Renderers;
using System;
using System.Runtime.Remoting.Contexts;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessDatePicker), typeof(BorderlessDatePickerRender))]
namespace SportDirect.Droid.Renderers
{
   public  class BorderlessDatePickerRender : DatePickerRenderer
    {
        //public BorderlessDatePickerRender(Context context) : base(context)
        //{

        //}
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);
            //  this.Control.SetTextColor(Android.Graphics.Color.Rgb(83, 63, 149));
            this.Control.SetBackgroundColor(Android.Graphics.Color.Transparent);
            this.Control.SetPadding(20, 0, 0, 0);

            //GradientDrawable gd = new GradientDrawable();
            //gd.SetCornerRadius(25); //increase or decrease to changes the corner look  
            //gd.SetColor(Android.Graphics.Color.Transparent);
            //gd.SetStroke(3, Android.Graphics.Color.Rgb(83, 63, 149));

            //this.Control.SetBackgroundDrawable(gd);

            BorderlessDatePicker element = Element as BorderlessDatePicker;

            if (!string.IsNullOrWhiteSpace(element.Placeholder))
            {
                Control.Text = element.Placeholder;
            }

            this.Control.TextChanged += (sender, arg) => {
                var selectedDate = arg.Text.ToString();
                if (selectedDate == element.Placeholder)
                {
                    Control.Text = DateTime.Now.ToString("dd/MM/yyyy");
                }
            };
        }
    }
}
