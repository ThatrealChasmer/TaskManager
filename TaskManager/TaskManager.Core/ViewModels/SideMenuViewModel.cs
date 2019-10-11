using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TaskManager.Core
{
    public class SideMenuViewModel : BaseViewModel
    {
        #region Commands

        public ICommand AddCommand { get; set; }

        #endregion

        public SideMenuViewModel()
        {
            AddCommand = new RelayCommand(() => Add());
        }

        private void Add()
        {
            IoCContainer.Get<ApplicationViewModel>().CurrentPage = ApplicationPage.Adding;
        }
    }
}
