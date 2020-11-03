using Workspace.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Workspace.ViewModels;

namespace Workspace
{
    public class WorkspaceModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {

        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<Main, MainViewModel>("Workspace");
            containerRegistry.RegisterForNavigation<Specialities, SpecialitiesViewModel>("Specialities");      
            containerRegistry.RegisterForNavigation<Analysis, AnalysisViewModel>("Analyze");
            containerRegistry.RegisterForNavigation<DocsEnrollment, DocsEnrollmentViewModel>("DocsEnrollment");
        }
    }
}