using System;
using System.Globalization;

namespace SportDirect.Core.Helpers
{
    public static class DateHelper
    {
        public static DateTime ParseDate(string date, string format = "dd/MM/yyyy")
        {
            var success = DateTime.TryParseExact(date, format, CultureInfo.InvariantCulture, DateTimeStyles.None,
                out var result);

            return result;
        }

        public static DateTime GetUtcSafe(this DateTime datetime)
        {
            if (datetime.Kind == DateTimeKind.Utc)
            {
                return datetime;
            }
            else
            {
                return datetime.ToUniversalTime();
            }
        }

        public static string CurrentDateToString(string format = "yyyy-MM-dd")
        {
            return DateTime.UtcNow.ToString(format, CultureInfo.InvariantCulture);
        }
        public static string CurrentTimeToString(string format = "HH:mm")
        {
            TimeSpan currentDateTime = DateTime.Now.TimeOfDay;
            return currentDateTime.ToString(@"hh\:mm");
        }
    }
}
