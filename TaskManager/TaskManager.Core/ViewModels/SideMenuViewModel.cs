using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager.Core
{
    public class SideMenuViewModel : BaseViewModel
    {
        private string m_Order;

        #region Public Properties

        public int OrderID { get; set; } = 0;
        public string Order { get { return m_Order; } set { m_Order = value; Sort(); } }

        #endregion

        #region Commands

        public ICommand AddCommand { get; set; }

        public ICommand ChangeListCommand { get; set; }

        #endregion

        public SideMenuViewModel()
        {
            OnPropertyChanged(nameof(Order));
            OnPropertyChanged(nameof(OrderID));

            AddCommand = new RelayCommand(() => Add());
            ChangeListCommand = new RelayParameterizedCommand((parameter) => ChangeList(parameter));
        }

        public void Add()
        {
            IoCContainer.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Adding;
        }

        public void ChangeList(object parameter)
        {
            TaskState p = (TaskState)(Convert.ToInt32(parameter));

            IoCContainer.Get<ApplicationViewModel>().CurrentTaskType = p;
            IoCContainer.Get<ApplicationViewModel>().RefreshTasks();
        }

        public void Sort()
        {
            IoCContainer.Get<ApplicationViewModel>().OrderType = Order;
            IoCContainer.Get<ApplicationViewModel>().SortTasks();
        }
    }
}
