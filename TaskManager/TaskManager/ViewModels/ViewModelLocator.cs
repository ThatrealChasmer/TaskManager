using TaskManager.Core.IoC;
using TaskManager.Core.ViewModels;
using Ninject;

namespace TaskManager
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance { get; private set; } = new ViewModelLocator();
        public static ApplicationViewModel ApplicationViewModel => IoCContainer.Kernel.Get<ApplicationViewModel>();
    }
}
