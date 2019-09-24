using System;
using System.Collections.Generic;

namespace TaskManager.Core
{
    /// <summary>
    /// A view model for a side task list
    /// </summary>
    public class TaskListViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// List of all tasks
        /// </summary>
        public List<TaskListItemViewModel> Items { get; set; }


        #endregion
    }
}
