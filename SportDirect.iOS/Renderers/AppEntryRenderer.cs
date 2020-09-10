using System;
using System.ComponentModel;
using CoreGraphics;
using SportDirect.Controls;
using SportDirect.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AppEntry), typeof(AppEntryRenderer))]
namespace SportDirect.iOS.Renderers
{
    public class AppEntryRenderer : EntryRenderer
    {
        private AppEntry _appEntry = null;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control == null || e.OldElement != null || this.Element == null)
                return;
            _appEntry = (this.Element as AppEntry);
            Control.BorderStyle = UITextBorderStyle.None;
            Control.LeftView = new UIView(new CGRect(0f, 0f, 9f, 20f));
            Control.LeftViewMode = UITextFieldViewMode.Always;
            UpdateBorderWidth(_appEntry);
            UpdateBorderColor(_appEntry);
            UpdateBorderRadius(_appEntry);
            //UpdateLeftPadding(_appEntry);
            //UpdateRightPadding(_appEntry);
            Control.ClipsToBounds = true;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null)
                return;
            var entryEx = Element as AppEntry;
            if (e.PropertyName == AppEntry.BorderWidthProperty.PropertyName)
            {
                UpdateBorderWidth(_appEntry);
            }
            else if (e.PropertyName == AppEntry.BorderColorProperty.PropertyName)
            {
                UpdateBorderColor(_appEntry);
            }
            else if (e.PropertyName == AppEntry.CornerRadiusProperty.PropertyName)
            {
                UpdateBorderRadius(_appEntry);
            }
        }
        private void UpdateBorderWidth(AppEntry entryEx)
        {
            Control.Layer.BorderWidth = entryEx.BorderWidth;
        }

        private void UpdateBorderColor(AppEntry entryEx)
        {
            Control.Layer.BorderColor = entryEx.BorderColor.ToUIColor().CGColor;
        }

        private void UpdateBorderRadius(AppEntry entryEx)
        {
            Control.Layer.CornerRadius = (nfloat)entryEx.CornerRadius;
        }
        //private void UpdateLeftPadding(AppEntry entryEx)
        //{
        //    var leftPaddingView = new UIView(new CGRect(0, 0, entryEx.LeftPadding, 0));
        //    Control.LeftView = leftPaddingView;
        //    Control.LeftViewMode = UITextFieldViewMode.Always;
        //}

        //private void UpdateRightPadding(AppEntry entryEx)
        //{
        //    var rightPaddingView = new UIView(new CGRect(0, 0, entryEx.RightPadding, 0));
        //    Control.RightView = rightPaddingView;
        //    Control.RightViewMode = UITextFieldViewMode.Always;
        //}
    }
}
