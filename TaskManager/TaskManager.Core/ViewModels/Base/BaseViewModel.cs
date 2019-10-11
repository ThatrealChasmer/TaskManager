using PropertyChanged;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TaskManager.Core
{
    // Base View Model that fires Property Changed events as needed
    public class BaseViewModel : INotifyPropertyChanged, INotifyCollectionChanged
    {
        // Event fired when any child property changes its value
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
        public event NotifyCollectionChangedEventHandler CollectionChanged = (sender, e) => { };

        /// <summary>
        /// Call this to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>
        public void OnPropertyChanged(string name) => PropertyChanged(this, new PropertyChangedEventArgs(name));
        public void OnCollectionChanged(NotifyCollectionChangedAction action, object element) => CollectionChanged(this, new NotifyCollectionChangedEventArgs(action, element));

        #region Command Helpers
        /*
        protected async Task RunCommand(Expression<Func<bool>> updatingFlag, Func<Task> action)
        {
            if (updatingFlag.GetPropertyValue())
                return;

            updatingFlag.SetPropertyValue(true);

            try
            {
                await action();
            }
            finally
            {
                updatingFlag.SetPropertyValue(false);
            }
        }
        */
        #endregion
    }
}
