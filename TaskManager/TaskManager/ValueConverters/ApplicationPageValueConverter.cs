using System;
using System.Diagnostics;
using System.Globalization;
using TaskManager.Core;

namespace TaskManager
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Return a page corresponding wih converted value
            switch((ApplicationPage)value)
            {
                case ApplicationPage.Start:
                    return null;
                case ApplicationPage.Task:
                    return new TaskPage();
                case ApplicationPage.Adding:
                    return new AddingPage();
                case ApplicationPage.Editing:
                    return new EditPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
