using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    /// <summary>
    /// Application state as a view model
    /// </summary>
    public class ApplicationViewModel : BaseViewModel
    {
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Start;

        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();

        public Task CurrentTask {
            get;
            set;
        }

        public ApplicationViewModel()
        {
            OnPropertyChanged(nameof(CurrentPage));
            OnPropertyChanged(nameof(CurrentTask));

            RefreshTasks();
        }

        public void RefreshTasks()
        {
            List<Task> fromDB = SQLConnectionHandler.Instance.GetTasks();

            foreach(var taskDB in fromDB)
            {
                bool canAdd = true;
                foreach(var task in Tasks)
                {
                    if(taskDB == task)
                    {
                        canAdd = false;
                        break;
                    }
                }
                if(canAdd)
                {
                    Tasks.Add(taskDB);
                }
            }
        }
    }
}
