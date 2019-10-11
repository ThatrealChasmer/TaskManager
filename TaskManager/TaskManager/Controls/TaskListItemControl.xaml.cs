using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskManager.Core;

namespace TaskManager
{
    /// <summary>
    /// Logika interakcji dla klasy TaskListItemControl.xaml
    /// </summary>
    public partial class TaskListItemControl : UserControl
    {
        public TaskListItemControl()
        {
            InitializeComponent();
        }

        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var vm = DataContext as TaskListItemViewModel;
            if (vm == null)
                return;

            IoCContainer.Get<ApplicationViewModel>().CurrentTask = vm.Task;
            IoCContainer.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Task;
        }
    }
}
