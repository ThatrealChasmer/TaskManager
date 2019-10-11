using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    public class TaskViewModel : BaseViewModel
    {
        #region Public Properties

        public string Title { get; set; }

        public string Contents { get; set; }

        public DateTime Added { get; set; }

        public DateTime End { get; set; }

        public Priority Priority { get; set; }

        public TaskState State { get; set; }

        #endregion

        #region Constructor

        public TaskViewModel()
        {
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Contents));
            OnPropertyChanged(nameof(Added));
            OnPropertyChanged(nameof(End));
            OnPropertyChanged(nameof(Priority));
            OnPropertyChanged(nameof(State));

            Refresh();

            IoCContainer.Get<ApplicationViewModel>().PropertyChanged += (s, e) => Refresh();
        }

        #endregion

        void Refresh()
        {
            var ct = IoCContainer.Get<ApplicationViewModel>().CurrentTask;

            Title = ct.Title;
            Contents = ct.Contents;
            Added = ct.StartDate;
            End = ct.EndDate;
            Priority = ct.Priority;
            State = ct.State;
        }
    }
}
