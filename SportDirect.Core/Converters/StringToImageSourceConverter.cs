using System;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace SportDirect.Core.Converters
{
    public class StringToImageSourceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            return ImageSource.FromResource((string)value, typeof(StringToImageSourceConverter).GetTypeInfo().Assembly);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
