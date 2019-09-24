using System;
using System.Globalization;
using System.Windows.Media;

namespace TaskManager
{
    /// <summary>
    /// Converts task's priority to WPF brush
    /// </summary>
    public class PriorityToBrushConverter : BaseValueConverter<PriorityToBrushConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var priority = (Priority)value;
            switch(priority)
            {
                case Priority.Low:
                    return new SolidColorBrush(Colors.Green);
                case Priority.Normal:
                    return new SolidColorBrush(Colors.Yellow);
                case Priority.High:
                    return new SolidColorBrush(Colors.Red);
                default:
                    return new SolidColorBrush(Colors.Transparent);
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
