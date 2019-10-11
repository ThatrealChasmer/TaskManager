using Ninject;
using System;
using System.Globalization;
using TaskManager.Core;

namespace TaskManager
{
    /// <summary>
    /// Converts a string name to a service pulled from IoC container
    /// </summary>
    class IoCConverter : BaseValueConverter<IoCConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((string)value)
            {
                case nameof(ApplicationViewModel):
                    return IoCContainer.Kernel.Get<ApplicationViewModel>();
                default:
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
