using Authorization.ViewModels;
using Authorization.Views;
using Prism.Ioc;
using Prism.Modularity;

namespace Authorization
{
    public class AuthorizationModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Login, LoginWindowViewModel>("Authorization");
        }
    }
}