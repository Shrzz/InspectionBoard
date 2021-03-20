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
            RegisterStudentDialogs(containerRegistry);
            RegisterSubjectDialogs(containerRegistry);
            RegisterTeacherDialogs(containerRegistry);
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthorizationModule>();
            moduleCatalog.AddModule<WorkspaceModule>();
        }

        private void RegisterLegacyDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.RegisterDialog<DocsSettingsDialog, DocsSettingsDialogViewModel>();
        }

        private void RegisterSubjectDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddSubjectDialog, AddSubjectDialogViewModel>("AddSubjectDialog");
            containerRegistry.RegisterDialog<EditSubjectDialog, EditSubjectDialogViewModel>("EditSubjectDialog");
            containerRegistry.RegisterDialog<RemoveSubjectDialog, RemoveSubjectDialogViewModel>("RemoveSubjectDialog");
        }

        private void RegisterStudentDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddStudentDialog, AddStudentDialogViewModel>("AddStudentDialog");
            containerRegistry.RegisterDialog<EditStudentDialog, EditStudentDialogViewModel>("EditStudentDialog");
            containerRegistry.RegisterDialog<RemoveStudentDialog, RemoveStudentDialogViewModel>("RemoveStudentDialog");
        }

        private void RegisterTeacherDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddTeacherDialog, AddTeacherDialogViewModel>("AddTeacherDialog");
            containerRegistry.RegisterDialog<EditTeacherDialog, EditTeacherDialogViewModel>("EditTeacherDialog");
            containerRegistry.RegisterDialog<RemoveTeacherDialog, RemoveTeacherDialogViewModel>("RemoveTeacherDialog");
        }
    }
}
