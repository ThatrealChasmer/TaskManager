using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using TaskManager.Core;

namespace TaskManager
{
    public class StateToVisibilityConverter : BaseValueConverter<StateToVisibilityConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            TaskState s = (TaskState)value;

            if(parameter != null)
            {
                if (s == TaskState.Finished) return Visibility.Collapsed;
            }
            else
            {
                if (s == TaskState.Progress) return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
