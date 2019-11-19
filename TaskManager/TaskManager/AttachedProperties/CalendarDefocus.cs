using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskManager
{
    class CalendarDefocus : BaseAttachedProperty<CalendarDefocus, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if(sender is Calendar)
            {
                Calendar cal = sender as Calendar;
                cal.PreviewMouseDown += (s, ee) =>
                {
                    if (Mouse.Captured is Calendar || Mouse.Captured is System.Windows.Controls.Primitives.CalendarItem)
                    {
                        Mouse.Capture(null);
                    }
                };
            }
        }
    }
}
