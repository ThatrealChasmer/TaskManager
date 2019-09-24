using System;

namespace TaskManager.Core
{
    /// <summary>
    /// A view model for each task list item in side task list
    /// </summary>
    public class TaskListItemViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// Title of the task
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Contents of the task
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Date the task have to be done until
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// Priority of the task
        /// </summary>
        public Priority Priority { get; set; }

        public bool IsSelected { get; set; }

        #endregion
    }
}
