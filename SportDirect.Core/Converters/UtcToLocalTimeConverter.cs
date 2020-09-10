using System;
using System.Globalization;
using Xamarin.Forms;

namespace SportDirect.Core.Converters
{
    public class UtcToLocalTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null || value.GetType() != typeof(DateTime))
            {
                return DateTime.MinValue;
            }

            var utcDateTime = DateTime.SpecifyKind((DateTime)value, DateTimeKind.Utc);
            return utcDateTime.ToLocalTime();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
