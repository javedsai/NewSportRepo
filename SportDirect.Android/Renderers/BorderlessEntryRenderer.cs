using System;
using Android.Content;
using SportDirect.Controls;
using SportDirect.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryRenderer))]
namespace SportDirect.Droid.Renderers
{
    public class BorderlessEntryRenderer : EntryRenderer
    {
        public BorderlessEntryRenderer(Context context):base(context)
        {

        }
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
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
