using System;
using Xamarin.Forms;

namespace SportDirect.Core.Converters
{
    public class ValidDateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && ValidateDate((DateTime)value))
                return ((DateTime)value).ToString("dd/MM/yyyy");
            return "";
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (string.IsNullOrEmpty((string)value)) return DateTime.MinValue;

            return DateTime.Parse((string)value);
        }

        private bool ValidateDate(DateTime newDateTimeValue)
        {
            if (DateTime.Parse("1/1/1900 12:00:00 AM") == newDateTimeValue ||
                DateTime.Parse("1/1/0001 12:00:00 AM") == newDateTimeValue)
            {
                return false;
            }

            return true;
        }
    }
}
