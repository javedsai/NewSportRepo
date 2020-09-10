using System;
using Android.Content;
using Android.Views;
using SportDirect.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(WebView), typeof(PdfWebViewRenderer))]
namespace SportDirect.Droid.Renderers
{
    public class PdfWebViewRenderer : WebViewRenderer
	{
        public PdfWebViewRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.Settings.AllowFileAccess = true;
                Control.Settings.AllowFileAccessFromFileURLs = true;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.SetSupportZoom(true);
                Control.Settings.BuiltInZoomControls = true;
                Control.Settings.BuiltInZoomControls = true;
            }
        }
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            Parent.RequestDisallowInterceptTouchEvent(true);
            return base.DispatchTouchEvent(e);
        }
    }
}
