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
        public DateTime DateTime { get; set; }
        public int Priority { get; set; } = 1;
        public int State { get; set; } = 0;

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

            AddCommand = new RelayCommand(() => Add());
        }

        #endregion

        private void Add()
        {
            Core.Priority p = Core.Priority.Normal;
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

            Task toAdd = new Task(Title, Contents, DateTime.Today, DateTime, p, s);
            
            IoCContainer.Get<ApplicationViewModel>().Tasks.Add(toAdd);
        }
    }
}
