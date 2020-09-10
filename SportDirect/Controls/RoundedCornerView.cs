using System;
using Xamarin.Forms;

namespace SportDirect.Controls
{
    public class RoundedCornerView : Grid
    {
        private static BindableProperty FillColorProperty = BindableProperty.Create(
            propertyName: "FillColor",
            returnType: typeof(Color),
            declaringType: typeof(RoundedCornerView),
            defaultValue: Color.White,
            defaultBindingMode: BindingMode.TwoWay
        );

        public Color FillColor
        {
            get { return (Color)GetValue(FillColorProperty); }
            set { SetValue(FillColorProperty, value); }
        }

        public static readonly BindableProperty RoundedCornerRadiusProperty = BindableProperty.Create("RoundedCornerRadius", typeof(double), typeof(RoundedCornerView), 3.0);

        public double RoundedCornerRadius
        {
            get { return (double)GetValue(RoundedCornerRadiusProperty); }
            set { SetValue(RoundedCornerRadiusProperty, value); }
        }

        public static readonly BindableProperty MakeCircleProperty = BindableProperty.Create("MakeCircle", typeof(Boolean), typeof(RoundedCornerView), false);

        public Boolean MakeCircle
        {
            get { return (Boolean)GetValue(MakeCircleProperty); }
            set { SetValue(MakeCircleProperty, value); }
        }

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create("BorderColor", typeof(Color), typeof(RoundedCornerView), Color.Transparent);

        public Color BorderColor
        {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create("BorderWidth", typeof(int), typeof(RoundedCornerView), 1);

        public int BorderWidth
        {
            get { return (int)GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }
        public RoundedCornerView()
        {
        }
    }
}
