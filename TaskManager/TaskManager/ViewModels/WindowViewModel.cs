using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace TaskManager
{
    public class WindowViewModel : BaseViewModel
    {
        #region Private Members

        private Window mWindow;

        private int mOuterMarginSize = 10;
        private int mWindowRadius = 10;

        #endregion

        #region Commands

        public ICommand MinimizeCommand { get; set; }

        public ICommand MaximizeCommand { get; set; }

        public ICommand CloseCommand { get; set; }

        public ICommand MenuCommand
        {
            get;
            set;
        }

        #endregion

        #region Public Properties

        public double WindowMinimumWidth { get; set; } = 700;

        public double WindowMinimumHeight { get; set; } = 400;

        public int InnerContentPadding { get; set; } = 6;

        public Thickness InnerContentPaddingThickness { get { return new Thickness(0); } }

        public int ResizeBorder { get; set; } = 2;

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + OuterMarginSize); } }

        public int OuterMarginSize
        {
            get
            {
                if (mWindow.WindowState == WindowState.Maximized)
                {
                    return 0;
                }
                else
                {
                    return mOuterMarginSize;
                }
            }
            set
            {
                mOuterMarginSize = value;
            }
        }

        public Thickness OuterMarginSizeThickness { get { return new Thickness(OuterMarginSize); } }

        public int WindowRadius
        {
            get
            {
                if(mWindow.WindowState == WindowState.Maximized)
                {
                    return 0;
                }
                else
                {
                    return mWindowRadius;
                }
            }
            set
            {
                mWindowRadius = value;
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int TitleHeight { get; set; } = 25;

        public GridLength TitleHeightGridLength { get { return new GridLength(TitleHeight + ResizeBorder); } }

        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;

        #endregion

        #region Constructor

        public WindowViewModel(Window window)
        {
            mWindow = window;

            mWindow.StateChanged += (sender, e) =>
            {
                OnPropertyChanged(nameof(ResizeBorderThickness));
                OnPropertyChanged(nameof(OuterMarginSize));
                OnPropertyChanged(nameof(OuterMarginSizeThickness));
                OnPropertyChanged(nameof(WindowRadius));
                OnPropertyChanged(nameof(WindowCornerRadius));
            };

            MinimizeCommand = new RelayCommand(() => mWindow.WindowState = WindowState.Minimized);
            MaximizeCommand = new RelayCommand(() => mWindow.WindowState ^= WindowState.Maximized);
            CloseCommand = new RelayCommand(() => mWindow.Close());
            MenuCommand = new RelayCommand(() => SystemCommands.ShowSystemMenu(mWindow, GetMousePosition()));

            var resizer = new WindowResizer(mWindow);
        }

        #endregion

        #region Helpers

        private Point GetMousePosition()
        {
            Point position = Mouse.GetPosition(mWindow);

            return new Point(position.X + mWindow.Left, position.Y + mWindow.Top);
        }

        #endregion
    }
}
