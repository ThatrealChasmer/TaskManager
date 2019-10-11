using System;
using System.Collections.Generic;

namespace TaskManager.Core
{
    /// <summary>
    /// A view model for each task list item in side task list
    /// </summary>
    public class TaskListDesignViewModel : TaskListViewModel
    {
        public static TaskListDesignViewModel Instance => new TaskListDesignViewModel();
        public TaskListDesignViewModel()
        {
            OnPropertyChanged(nameof(Items));

            Items = new System.Collections.ObjectModel.ObservableCollection<TaskListItemViewModel>
            {
                new TaskListItemViewModel
                {
                    Title = "TaskManager for work",
                    Contents = "Create a task manager for job application. It should allow to edit tasks",
                    EndDate = new DateTime(2019, 9, 25),
                    Priority = Priority.High
                 },
                new TaskListItemViewModel
                {
                    Title = "Pack for moving into new flat",
                    Contents = "Pack all the things I need and prepare for moving into the new flat",
                    EndDate = new DateTime(2019, 9, 27),
                    Priority = Priority.Normal,
                    IsSelected = true
                 },
                new TaskListItemViewModel
                {
                    Title = "Farm mats in MHW",
                    Contents = "Iceborne is coming, farm all materials and streamstones you need",
                    EndDate = new DateTime(2020, 1, 15),
                    Priority = Priority.Low
                 },
                new TaskListItemViewModel
                {
                    Title = "TaskManager for work",
                    Contents = "Create a task manager for job application. It should allow to edit tasks",
                    EndDate = new DateTime(2019, 9, 25),
                    Priority = Priority.High
                 },
                new TaskListItemViewModel
                {
                    Title = "Pack for moving into new flat",
                    Contents = "Pack all the things I need and prepare for moving into the new flat",
                    EndDate = new DateTime(2019, 9, 27),
                    Priority = Priority.Normal
                 },
                new TaskListItemViewModel
                {
                    Title = "Farm mats in MHW",
                    Contents = "Iceborne is coming, farm all materials and streamstones you need",
                    EndDate = new DateTime(2020, 1, 15),
                    Priority = Priority.Low
                 },
                new TaskListItemViewModel
                {
                    Title = "TaskManager for work",
                    Contents = "Create a task manager for job application. It should allow to edit tasks",
                    EndDate = new DateTime(2019, 9, 25),
                    Priority = Priority.High
                 },
                new TaskListItemViewModel
                {
                    Title = "Pack for moving into new flat",
                    Contents = "Pack all the things I need and prepare for moving into the new flat",
                    EndDate = new DateTime(2019, 9, 27),
                    Priority = Priority.Normal
                 },
                new TaskListItemViewModel
                {
                    Title = "Farm mats in MHW",
                    Contents = "Iceborne is coming, farm all materials and streamstones you need",
                    EndDate = new DateTime(2020, 1, 15),
                    Priority = Priority.Low
                 },
                new TaskListItemViewModel
                {
                    Title = "TaskManager for work",
                    Contents = "Create a task manager for job application. It should allow to edit tasks",
                    EndDate = new DateTime(2019, 9, 25),
                    Priority = Priority.High
                 },
                new TaskListItemViewModel
                {
                    Title = "Pack for moving into new flat",
                    Contents = "Pack all the things I need and prepare for moving into the new flat",
                    EndDate = new DateTime(2019, 9, 27),
                    Priority = Priority.Normal
                 },
                new TaskListItemViewModel
                {
                    Title = "Farm mats in MHW",
                    Contents = "Iceborne is coming, farm all materials and streamstones you need",
                    EndDate = new DateTime(2020, 1, 15),
                    Priority = Priority.Low
                 },
            };
        }
    }
}
