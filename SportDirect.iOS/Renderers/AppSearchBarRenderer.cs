using System;
using System.ComponentModel;
using SportDirect.Controls;
using SportDirect.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(AppSearchBar), typeof(AppSearchBarRenderer))]
namespace SportDirect.iOS.Renderers
{
    public class AppSearchBarRenderer : SearchBarRenderer
    {
        private AppSearchBar _appSearchBar = null;
        public AppSearchBarRenderer()
        {
        }
        protected override void OnElementChanged(ElementChangedEventArgs<SearchBar> e)
        {
            base.OnElementChanged(e);
            if (Control == null || e.OldElement != null || this.Element == null)
                return;
            //Control.SearchBarStyle = UISearchBarStyle.Minimal;
            //Control.BarTintColor = UIColor.Clear;
            _appSearchBar = (this.Element as AppSearchBar);
            UpdateBorderWidth(_appSearchBar);
            UpdateBorderColor(_appSearchBar);
            UpdateBorderRadius(_appSearchBar);
            Control.ClipsToBounds = true;
        }
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (this.Element == null)
                return;
            var searchBar = Element as AppSearchBar;
            if (e.PropertyName == AppSearchBar.BorderWidthProperty.PropertyName)
            {
                UpdateBorderWidth(searchBar);
            }
            else if (e.PropertyName == AppSearchBar.BorderColorProperty.PropertyName)
            {
                UpdateBorderColor(searchBar);
            }
            else if (e.PropertyName == AppSearchBar.CornerRadiusProperty.PropertyName)
            {
                UpdateBorderRadius(searchBar);
            }
        }
        private void UpdateBorderWidth(AppSearchBar searchBar)
        {
            Control.Layer.BorderWidth = searchBar.BorderWidth;
        }

        private void UpdateBorderColor(AppSearchBar searchBar)
        {
            Control.Layer.BorderColor = searchBar.BorderColor.ToUIColor().CGColor;
        }

        private void UpdateBorderRadius(AppSearchBar searchBar)
        {
            Control.Layer.CornerRadius = (nfloat)searchBar.CornerRadius;
        }

    }
}
