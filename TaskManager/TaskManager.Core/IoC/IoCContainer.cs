using Ninject;

namespace TaskManager.Core
{
    /// <summary>
    /// IoC container for application
    /// </summary>
    public static class IoCContainer
    {
        /// <summary>
        /// Kernel for our IoC container
        /// </summary>
        public static IKernel Kernel { get; private set; } = new StandardKernel();

        /// <summary>
        /// sets container and binds all information required
        /// NOTE: must be called as soon as application start
        /// </summary>
        public static void Setup()
        {
            //Bind all required view models
            BindViewModels();
        }

        /// <summary>
        /// Binds all singleton view models
        /// </summary>
        private static void BindViewModels()
        {
            // Bind to single instance of ApplicationViewModel 
            Kernel.Bind<ApplicationViewModel>().ToConstant(new ApplicationViewModel());
        }

        /// <summary>
        /// Helper function to get given binded view model
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>()
        {
            return Kernel.Get<T>();
        }
    }
}
