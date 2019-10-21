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

        /// <summary>
        /// Opening task on click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserControl_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // Get view model of the task to show
            TaskListItemViewModel vm = DataContext as TaskListItemViewModel;

            // Check if the viewmodel exists, if it doesn't return
            if (vm == null)
                return;

            // Set current task
            IoCContainer.Get<ApplicationViewModel>().CurrentTask = vm.Task;

            // Set app page to task page
            IoCContainer.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Task;
        }
    }
}
