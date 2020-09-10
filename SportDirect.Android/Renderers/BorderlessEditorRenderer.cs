using System;
using Android.Content;
using SportDirect.Controls;
using SportDirect.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(BorderlessEditor), typeof(BorderlessEditorRenderer))]
namespace SportDirect.Droid.Renderers
{
    public class BorderlessEditorRenderer : EditorRenderer
    {
        public BorderlessEditorRenderer(Context context):base(context)
        {
        }
        public static void Init() { }
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            if (Control == null || e.OldElement != null || this.Element == null)
                return;
            if (e.OldElement == null)
            {
                Control.Background = null;

                var layoutParams = new MarginLayoutParams(Control.LayoutParameters);
                layoutParams.SetMargins(0, 0, 0, 0);
                LayoutParameters = layoutParams;
                Control.LayoutParameters = layoutParams;
                Control.SetPadding(0, 0, 0, 0);
                SetPadding(0, 0, 0, 0);
            }
        }
    }
}
