using System;
using System.Windows.Input;

namespace TaskManager.Core
{
    /// <summary>
    /// A view model for each task list item in side task list
    /// </summary>
    public class NoteViewModel : BaseViewModel
    {
        #region Public Properties

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

        public ICommand DeleteCommand;

        #endregion

        #region Constructor

        public NoteViewModel()
        {
            DeleteCommand = new RelayCommand(() => Delete());
        }

        #endregion

        public void Delete()
        {
            //TODO: add deleting system
        }
    }
}
