using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskManager.Core
{
    public class TaskViewModel : BaseViewModel
    {
        #region Public Properties

        public int ID { get; set; }

        public string Title { get; set; }

        public string Contents { get; set; }

        public DateTime Added { get; set; }

        public DateTime End { get; set; }

        public Priority Priority { get; set; }

        public TaskState State { get; set; }

        public bool NoteTBVisibility { get; set; } = false;

        public bool AddBtnVisiblity { get; set; } = true;

        public string NoteText { get; set; }

        public ObservableCollection<NoteViewModel> Notes { get; set; } = new ObservableCollection<NoteViewModel>();

        #endregion

        #region Commands

        public ICommand AddNoteCommand { get; set; }

        public ICommand SaveNoteCommand { get; set; }

        public ICommand EditCommand { get; set; }

        public ICommand DeleteCommand { get; set; }

        public ICommand MoveToCommand { get; set; }

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
            OnPropertyChanged(nameof(AddBtnVisiblity));
            OnPropertyChanged(nameof(NoteTBVisibility));
            OnPropertyChanged(nameof(NoteText));
            OnPropertyChanged(nameof(Notes));

            Refresh();

            AddNoteCommand = new RelayCommand(() => AddNote());
            SaveNoteCommand = new RelayCommand(() => SaveNote());
            EditCommand = new RelayCommand(() => Edit());
            DeleteCommand = new RelayCommand(() => Delete());
            MoveToCommand = new RelayParameterizedCommand((parameter) => MoveTo(parameter));

            IoCContainer.Get<ApplicationViewModel>().PropertyChanged += (s, e) => Refresh();
        }

        #endregion

        public void SaveNote()
        {
            Note toAdd = new Note(0, ID, NoteText, DateTime.Today);

            SQLConnectionHandler.Instance.AddNote(toAdd);

            RefreshNotes();

            AddBtnVisiblity = true;
            NoteTBVisibility = false;
        }

        public void AddNote()
        {
            AddBtnVisiblity = false;
            NoteTBVisibility = true;
        }

        public void Edit()
        {
            IoCContainer.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Editing;
        }

        void Refresh()
        {
            var ct = IoCContainer.Get<ApplicationViewModel>().CurrentTask;

            if (ct != null)
            {
                ID = ct.ID;
                Title = ct.Title;
                Contents = ct.Contents;
                Added = ct.StartDate;
                End = ct.EndDate;
                Priority = ct.Priority;
                State = ct.State;

                RefreshNotes();
            }
        }

        void RefreshNotes()
        {
            Notes.Clear();

            List<Note> fromDB = SQLConnectionHandler.Instance.GetNotes(ID);
            
            foreach(Note n in fromDB)
            {
                Notes.Add(new NoteViewModel
                {
                    Added = n.Added,
                    Contents = n.Contents
                });
            }
        }

        public void MoveTo(object p)
        {
            TaskState s = (TaskState)(Convert.ToInt32(p));
            SQLConnectionHandler.Instance.MoveTask(ID, s);

            IoCContainer.Get<ApplicationViewModel>().RefreshTasks();

            IoCContainer.Get<ApplicationViewModel>().CurrentTaskType = State;

            Refresh();
        }

        public void Delete()
        {
            SQLConnectionHandler.Instance.DeleteTask(ID);

            IoCContainer.Get<ApplicationViewModel>().CurrentTask = null;

            IoCContainer.Get<ApplicationViewModel>().RefreshTasks();

            IoCContainer.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Start;
        }
    }
}
