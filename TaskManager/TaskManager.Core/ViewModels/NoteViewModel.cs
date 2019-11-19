using System;
using System.Windows.Input;

namespace TaskManager.Core
{
    /// <summary>
    /// A view model for each note item in task
    /// </summary>
    public class NoteViewModel : BaseViewModel
    {
        #region Private Members

        int mID;

        #endregion

        #region Public Properties

        public int ID { get { return mID; } set { mID = value; } }

        /// <summary>
        /// Text of our note
        /// </summary>
        public string Contents { get; set; }

        /// <summary>
        /// Date we added the note
        /// </summary>
        public DateTime Added { get; set; }

        #endregion

        #region Commands

        public ICommand DeleteCommand { get; set; }

        #endregion

        #region Constructor

        public NoteViewModel()
        {
            DeleteCommand = new RelayCommand(() => Delete());
        }

        #endregion

        public void Delete()
        {
            SQLConnectionHandler.Instance.DeleteNote(ID);

            IoCContainer.Get<ApplicationViewModel>().CurrentTaskViewModel.RefreshNotes();
        }
    }
}
