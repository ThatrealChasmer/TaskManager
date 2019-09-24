using System;
using System.Windows.Input;

namespace TaskManager.Core
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        // Action to run
        private Action mAction;

        #endregion

        #region Public Events

        /// <summary>
        /// Event fired when <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor

        // Default constructor
        public RelayCommand(Action action)
        {
            mAction = action;
        }

        #endregion

        #region Command Methods

        // Relay command that always execute
        public bool CanExecute(object parameter)
        {
            return true;
        }

        // Executes command action
        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
