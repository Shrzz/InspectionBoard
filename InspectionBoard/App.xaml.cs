using Authorization;
using InspectionBoard.Dialogs;
using InspectionBoard.Dialogs.StudentsDialogs;
using InspectionBoard.Dialogs.SubjectsDialogs;
using InspectionBoard.Dialogs.TeachersDialog;
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
            containerRegistry.RegisterDialog<AddApplicantDialog, AddApplicantDialogViewModel>();
            containerRegistry.RegisterDialog<RemoveApplicantDialog, RemoveApplicantDialogViewModel>();
            containerRegistry.RegisterDialog<EditApplicantDialog, EditApplicantDialogViewModel>();
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.RegisterDialog<DocsSettingsDialog, DocsSettingsDialogViewModel>();

            RegisterAddDialogs(containerRegistry);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthorizationModule>();
            moduleCatalog.AddModule<WorkspaceModule>();
        }

        private void RegisterAddDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddTeacherDialog, AddTeacherDialogViewModel>("AddTeacherDialog");
            containerRegistry.RegisterDialog<AddStudentDialog, AddStudentDialogViewModel>("AddStudentDialog");
            containerRegistry.RegisterDialog<AddSubjectDialog, AddSubjectDialogViewModel>("AddSubjectDialog");
        }
    }
}
