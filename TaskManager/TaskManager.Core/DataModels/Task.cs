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
        #region Private Members

        /// <summary>
        /// ID of the task used to find it in database and is set only when retrieving task from it.
        /// </summary>
        int mID;

        /// <summary>
        /// Title of the task
        /// </summary>
        string mTitle;

        /// <summary>
        /// Contents of the task
        /// </summary>
        string mContents;

        /// <summary>
        /// Starting date, time is set to 00:00:00 by default
        /// </summary>
        DateTime mStartDate;

        /// <summary>
        /// End date of the task, time is set to 00:00:00 by default
        /// </summary>
        DateTime mEndDate;

        #endregion

        #region Constructor



        #endregion
    }
}
