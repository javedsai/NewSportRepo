using System;
using Xamarin.Forms;

namespace SportDirect.Controls
{
    public class AppSearchBar : SearchBar
    {
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(AppEntry), Color.Gray);
        // Gets or sets BorderColor value  
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(AppEntry), defaultValue: GetDefaultEntryBorderWidth());
        // Gets or sets BorderWidth value  
        public int BorderWidth
        {
            get => (int)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), typeof(double), typeof(AppEntry), defaultValue: GetDefaultEntryCornerRadius());
        // Gets or sets CornerRadius value  
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }


        public static readonly BindableProperty LeftPaddingProperty = BindableProperty.Create(nameof(LeftPadding), typeof(int), typeof(AppEntry), defaultValue: 5);

        public int LeftPadding
        {
            get { return (int)GetValue(LeftPaddingProperty); }
            set { SetValue(LeftPaddingProperty, value); }
        }

        public static BindableProperty RightPaddingProperty = BindableProperty.Create(nameof(RightPadding), typeof(int), typeof(AppEntry), defaultValue: 5);

        public int RightPadding
        {
            get { return (int)GetValue(RightPaddingProperty); }
            set { SetValue(RightPaddingProperty, value); }
        }
        public AppSearchBar():base()
        {
        }
        private static int GetDefaultEntryBorderWidth()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return 1;
                default:
                    return 2;
            }
        }
        private static double GetDefaultEntryCornerRadius()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.iOS:
                    return 6.0;
                default:
                    return 7.0;
            }
        }
    }
}
