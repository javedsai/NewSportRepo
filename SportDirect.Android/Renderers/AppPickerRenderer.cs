using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using SportDirect.Controls;
using SportDirect.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(AppPicker), typeof(AppPickerRenderer))]
namespace SportDirect.Droid.Renderers
{
    public class AppPickerRenderer : PickerRenderer
    {
        AppPicker element;
        public AppPickerRenderer(Context context) : base(context) { }
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            if (Control == null || e.OldElement != null || this.Element == null)
                return;
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}