using System;
using System.ComponentModel;
using Android.Content;
using Android.Graphics.Drawables;
using Android.Util;
using Android.Views;
using SportDirect.Controls;
using SportDirect.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(AppEntry), typeof(AppEntryRenderer))]
namespace SportDirect.Droid.Renderers
{
    public class AppEntryRenderer : EntryRenderer
    {
        private AppEntry _appEntry = null;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        public AppEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if ( Control == null ||e.OldElement != null || this.Element == null)
                return;
            _appEntry = (this.Element as AppEntry);
            UpdatePadding(_appEntry);
            UpdateTextAlighnment(_appEntry);
            UpdateBackground(_appEntry);
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;
            var entryEx = Element as AppEntry;
            if (e.PropertyName == AppEntry.BorderWidthProperty.PropertyName ||
                e.PropertyName == AppEntry.BorderColorProperty.PropertyName ||
                e.PropertyName == AppEntry.CornerRadiusProperty.PropertyName )
            {
                UpdateBackground(entryEx);
            }
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(entryEx);
            }
        }

        private void UpdatePadding(AppEntry entryEx)
        {
            // Set padding for the internal text from border  
            Control.SetPadding((int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingTop, (int)DpToPixels(this.Context, Convert.ToSingle(12)), Control.PaddingBottom);
        }

        private void UpdateTextAlighnment(AppEntry entryEx)
        {
            var gravity = DefaultGravity;
            switch (entryEx.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }
            Control.Gravity = gravity;
        }


        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
        private void UpdateBackground(AppEntry entryEx)
        {
            // creating gradient drawable for the curved background  
            var _gradientBackground = new GradientDrawable();
            _gradientBackground.SetShape(ShapeType.Rectangle);
            _gradientBackground.SetColor(entryEx.BackgroundColor.ToAndroid());

            // Thickness of the stroke line  
            _gradientBackground.SetStroke(entryEx.BorderWidth, entryEx.BorderColor.ToAndroid());

            // Radius for the curves  
            _gradientBackground.SetCornerRadius(DpToPixels(this.Context, Convert.ToSingle(entryEx.CornerRadius)));

            // set the background of the   
            Control.SetBackground(_gradientBackground);
        }
        //private void UpdatePadding(AppEntry entryEx)
        //{
        //    Control.SetPadding((int)Forms.Context.ToPixels(entryEx.LeftPadding), 0,
        //        (int)Forms.Context.ToPixels(entryEx.RightPadding), 0);
        //}
    }
}
