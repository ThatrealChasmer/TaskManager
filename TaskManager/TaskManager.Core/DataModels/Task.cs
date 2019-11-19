using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    /// <summary>
    /// Class for creating task objects
    /// </summary>
    public class Task
    {
        #region Public Properties

        /// <summary>
        /// ID of the task used to find it in database and is set only when retrieving task from it.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Title of the task
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Contents of the task
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Starting date, time is set to 00:00:00 by default
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the task, time is set to 00:00:00 by default
        /// </summary>
        public DateTime? EndDate { get; set; }

        public Priority Priority { get; set; }

        public TaskState State { get; set; }

        #endregion

        #region Constructor

        public Task(int id, string title, string contents, DateTime start, DateTime? end, Priority priority, TaskState state)
        {
            this.ID = id;
            this.Title = title;
            this.Contents = contents;
            this.StartDate = start;
            this.EndDate = end;
            this.Priority = priority;
            this.State = state;
        }

        #endregion
    }
}
