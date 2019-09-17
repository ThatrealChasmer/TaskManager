using System.Windows.Controls;
using System.Windows;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace TaskManager
{
    // Base page for all pages to gain some base functionality
    public class BasePage<VM>: Page
        where VM : BaseViewModel, new()
    {
        #region Private Members

        // View Model that is assosiated with this page
        private VM mViewModel;

        #endregion
        #region Public Properties

        
        // Public View Model that is assosiated with this page
        public VM ViewModel
        {
            get { return mViewModel; }

            set
            {
                if (mViewModel == value)
                    return;

                mViewModel = value;

                this.DataContext = mViewModel;
            }
        }

        #endregion

        #region Constructor

        // Default constructor
        public BasePage()
        {
            // Creating default View Model
            this.ViewModel = new VM();
        }

        #endregion

        #region Animation Load/Unload

        

        #endregion
    }
}
