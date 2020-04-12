using Authorization;
using InspectionBoard.Dialogs;
using InspectionBoard.ViewModels;
using InspectionBoard.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Prism.Unity;
using System.Windows;
using Workspace;

namespace InspectionBoard
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Main>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {    
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
          //  containerRegistry.RegisterForNavigation<Workspace.Views.ViewA, Workspace.ViewModels.ViewAViewModel>();
          //  containerRegistry.RegisterForNavigation<Authorization.Views.ViewA, Authorization.ViewModels.AuthorizationViewModel>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthorizationModule>();
            moduleCatalog.AddModule<WorkspaceModule>();
        }
    }
}
