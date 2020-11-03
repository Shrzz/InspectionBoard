using Authorization.ViewModels;
using Authorization.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace Authorization
{
    public class AuthorizationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
 
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Login, LoginViewModel>("Auth");
        }
    }
}