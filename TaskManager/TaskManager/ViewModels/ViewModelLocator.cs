using Ninject;
using TaskManager.Core;

namespace TaskManager
{
    /// <summary>
    /// Class containing all classes bound to kernel in <see cref="IoCContainer"/>
    /// </summary>
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => IoCContainer.Kernel.Get<ApplicationViewModel>();
    }
}
