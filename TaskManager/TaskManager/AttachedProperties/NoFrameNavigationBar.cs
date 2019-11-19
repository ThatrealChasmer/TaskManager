using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace TaskManager
{
    /// <summary>
    /// Attached property to keep default navigation bar hidden and remove <see cref="Frame"/> history
    /// </summary>
    public class NoFrameNavigationBar : BaseAttachedProperty<NoFrameNavigationBar, bool>
    {
        public override void OnValueChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            // Get the frame
            Frame frame = (sender as Frame);

            // Hide the navigation bar
            frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;

            // Clear back entry when navigating so the history is clear
            frame.Navigated += (ss, ee) => ((Frame)ss).NavigationService.RemoveBackEntry();
        }
    }
}
