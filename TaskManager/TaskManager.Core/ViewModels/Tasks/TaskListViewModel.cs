using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Input;

namespace TaskManager.Core
{
    /// <summary>
    /// A view model for a side task list
    /// </summary>
    public class TaskListViewModel : BaseViewModel
    {
        public ICommand RefreshCommand { get; set; }

        #region Public Properties

        /// <summary>
        /// List of all tasks
        /// </summary>
        public ObservableCollection<TaskListItemViewModel> Items { get; set; } = new ObservableCollection<TaskListItemViewModel>();


        #endregion

        #region Constructor

        public TaskListViewModel()
        {
            OnPropertyChanged(nameof(Items));

            RefreshCommand = new RelayCommand(() => Refresh());
            
            if(IoCContainer.Get<ApplicationViewModel>().Tasks.Count >= 0)
            {
                foreach (var task in IoCContainer.Get<ApplicationViewModel>().Tasks)
                {
                    Items.Add(
                        new TaskListItemViewModel
                        {
                            Task = task,
                            Title = task.Title,
                            Contents = task.Contents,
                            EndDate = task.EndDate,
                            Priority = task.Priority
                        });
                }
            }
            
            var AVM = IoCContainer.Get<ApplicationViewModel>();

            AVM.Tasks.CollectionChanged += (s, e) => Refresh();
        }

        #endregion

        public void Refresh()
        {
            Items.Clear();
            if (IoCContainer.Get<ApplicationViewModel>().Tasks.Count > 0)
            {
                
                foreach (Task task in IoCContainer.Get<ApplicationViewModel>().Tasks)
                {
                    Items.Add(
                        new TaskListItemViewModel
                        {
                            Task = task,
                            Title = task.Title,
                            Contents = task.Contents,
                            EndDate = task.EndDate,
                            Priority = task.Priority
                        });
                }
            }
        }
    }
}
