using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using TaskManager;

namespace TaskManager.Core
{
    public class AddingViewModel : BaseViewModel
    {
        #region Public Properties

        public string Title { get; set; }
        public string Contents { get; set; }
        public DateTime End { get; set; }
        public int Priority { get; set; } = 1;
        public int State { get; set; } = 0;

        public bool RequiredNotFilled { get; set; } = false;

        #endregion

        #region Commands

        public ICommand AddCommand { get; set; }

        #endregion

        #region Constructor

        public AddingViewModel()
        {
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Contents));
            OnPropertyChanged(nameof(DateTime));
            OnPropertyChanged(nameof(Priority));
            OnPropertyChanged(nameof(State));
            OnPropertyChanged(nameof(RequiredNotFilled));

            AddCommand = new RelayCommand(() => Add());
        }

        #endregion

        private void Add()
        {
            RequiredNotFilled = CheckRequired();

            if(!RequiredNotFilled)
            {
                Core.Priority p = Core.Priority.Normal;
                TaskState s = TaskState.New;
                switch (Priority)
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
                switch (State)
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

                Task toAdd = new Task(0, Title, Contents, DateTime.Today, End, p, s);

                SQLConnectionHandler.Instance.AddTask(toAdd);

                ApplicationViewModel AVM = IoCContainer.Get<ApplicationViewModel>();

                AVM.CurrentTaskType = toAdd.State;

                AVM.RefreshTasks();

                AVM.CurrentPage = ApplicationPage.Start;
            }
        }

        public bool CheckRequired()
        {
            if (Title != null && Contents != null)
            {
                return false;
            }
            else return true;
        }
    }
}
