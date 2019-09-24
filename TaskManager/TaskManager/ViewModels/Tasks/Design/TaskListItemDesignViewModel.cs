using System;

namespace TaskManager
{
    /// <summary>
    /// A view model for each task list item in side task list
    /// </summary>
    public class TaskListItemDesignViewModel : TaskListItemViewModel
    {
        public static TaskListItemDesignViewModel Instance => new TaskListItemDesignViewModel();
        public TaskListItemDesignViewModel()
        {
            Title = "TaskManager for work";
            Contents = "Create a task manager for job application. It should allow to edit tasks";
            EndDate = new DateTime(2019, 9, 25);
            Priority = Priority.High;
        }
    }
}
