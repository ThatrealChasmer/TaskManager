using System;
using System.Globalization;

namespace TaskManager
{
    public class DateTimeToStringConverter : BaseValueConverter<DateTimeToStringConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var date = (DateTime)value;
            string dateString = date.Day + "/" + date.Month + "/" + date.Year;
            return dateString;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
