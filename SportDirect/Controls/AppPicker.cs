using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SportDirect.Controls
{
    public class AppPicker : Picker
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Icon), typeof(string), typeof(AppPicker), string.Empty);
        public string Icon
        {
            get
            {
                return (string)GetValue(ImageProperty);
            }
            set
            {
                SetValue(ImageProperty, value);
            }
        }
    }
}
