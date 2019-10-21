using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager;

namespace TaskManager.Core
{
    public class EditViewModel : BaseViewModel
    {
        #region Private Members

        private int TaskID { get; set; }

        #endregion

        #region Public Properties

        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime DateTime { get; set; }
        public int Priority { get; set; } = 1;
        public int State { get; set; } = 0;

        #endregion

        #region Commands

        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor

        public EditViewModel()
        {
            Task task = IoCContainer.Get<ApplicationViewModel>().CurrentTask;

            TaskID = task.ID;
            Title = task.Title;
            Contents = task.Contents;
            DateTime = task.EndDate;
            Priority = (int)task.Priority;
            State = (int)task.State;


            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Contents));
            OnPropertyChanged(nameof(DateTime));
            OnPropertyChanged(nameof(Priority));
            OnPropertyChanged(nameof(State));

            SaveCommand = new RelayCommand(() => Save());
        }

        #endregion

        private void Save()
        {
            Priority p = Core.Priority.Normal;
            TaskState s = TaskState.New;
            switch(Priority)
            {
                case 0:
                    p = Core.Priority.Low;
                    break;
                case 1:
                    p = Core.Priority.Normal;
                    break;
                case 2:
                    p = Core.Priority.High;
                    break;
            }
            switch(State)
            {
                case 0:
                    s = TaskState.New;
                    break;
                case 1:
                    s = TaskState.Progress;
                    break;
                case 2:
                    s = TaskState.Finished;
                    break;
            }

            Task toEdit = new Task(TaskID, Title, Contents, DateTime.Today, DateTime, p, s);

            SQLConnectionHandler.Instance.EditTask(toEdit);

            IoCContainer.Get<ApplicationViewModel>().CurrentTaskType = toEdit.State;

            IoCContainer.Get<ApplicationViewModel>().RefreshTasks();

            IoCContainer.Get<ApplicationViewModel>().CurrentTask = toEdit;

            IoCContainer.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Task;
        }
    }
}
