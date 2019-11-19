using System;
using System.Globalization;

namespace TaskManager
{
    public class DateTimeToStringConverter : BaseValueConverter<DateTimeToStringConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime? date = (DateTime?)value;

            if (date == null) return "Not set...";
            
            string dateString = date.Value.Day + "/" + date.Value.Month + "/" + date.Value.Year;

            if (dateString == "1/1/1")
            {
                return "Select a date...";
            }
            return dateString;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
