using Documentation.ViewModels;
using Documentation.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Documentation
{
    public class DocumentationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Main, MainViewModel>("Documents");
        }
    }
}
