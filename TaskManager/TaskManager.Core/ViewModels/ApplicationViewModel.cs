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

        public TaskState CurrentTaskType { get; set; } = TaskState.Progress;

        public string OrderType { get; set; } = "Newest";

        public ObservableCollection<Task> Tasks { get; set; } = new ObservableCollection<Task>();

        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();

        public Task CurrentTask { get; set; }

        public ApplicationViewModel()
        {
            OnPropertyChanged(nameof(CurrentPage));
            OnPropertyChanged(nameof(CurrentTask));
            OnPropertyChanged(nameof(CurrentTaskType));

            RefreshTasks();
        }

        public void RefreshTasks()
        {
            Tasks.Clear();

            List<Task> fromDB = SQLConnectionHandler.Instance.GetTasks().Where(t => t.State == CurrentTaskType).ToList();

            foreach(Task task in fromDB)
            {
                Tasks.Add(task);
            }

            if (CurrentTask != null)
            {
                try
                {
                    CurrentTask = Tasks.Where(t => t.ID == CurrentTask.ID).First();

                }
                catch
                {
                    new NullReferenceException();
                }
            }

            SortTasks();
        }

        public void SortTasks()
        {
            List<Task> sorted = new List<Task>();

            switch(OrderType)
            {
                case "Newest":
                    sorted = Tasks.OrderByDescending(t => t.StartDate).ToList();
                    break;
                case "Oldest":
                    sorted = Tasks.OrderBy(t => t.StartDate).ToList();
                    break;
                case "Top priority":
                    sorted = Tasks.OrderByDescending(t => (int)t.Priority).ToList();
                    break;
                case "Lowest priority":
                    sorted = Tasks.OrderBy(t => (int)t.Priority).ToList();
                    break;
                case "Ending soon":
                    sorted = Tasks.OrderByDescending(t => t.EndDate).ToList();
                    break;
                case "A-Z":
                    sorted = Tasks.OrderBy(t => t.Title).ToList();
                    break;
                case "Z-A":
                    sorted = Tasks.OrderByDescending(t => t.Title).ToList();
                    break;
            }

            Tasks.Clear();
            foreach (Task task in sorted) Tasks.Add(task);
        }
    }
}
