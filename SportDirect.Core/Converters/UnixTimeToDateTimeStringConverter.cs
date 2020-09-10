using System;
using System.Globalization;
using Xamarin.Forms;

namespace SportDirect.Core.Converters
{
    public class UnixTimeToDateTimeStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null)
                return null;

            if (!long.TryParse(value.ToString(), out var unixTime))
                return null;

            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTime);
            var formatString = parameter as string;

            if (string.IsNullOrEmpty(formatString))
            {
                return dateTimeOffset.LocalDateTime;
            }

            return dateTimeOffset.LocalDateTime.ToString(formatString);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (parameter == null) throw new ArgumentNullException(nameof(parameter));
            throw new NotImplementedException();
        }
    }
}
