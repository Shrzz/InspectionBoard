using Authorization;
using InspectionBoard.Dialogs;
using InspectionBoard.Dialogs.DialogWindows;
using InspectionBoard.Dialogs.ExamsDialogs;
using InspectionBoard.Dialogs.GroupsDialogs;
using InspectionBoard.Dialogs.StudentsDialogs;
using InspectionBoard.Dialogs.SubjectsDialogs;
using InspectionBoard.Dialogs.TeachersDialog;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using Workspace;

namespace InspectionBoard
{
    public partial class App : PrismApplication
    {
        private IContainerRegistry containerRegistry;
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.Main>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            this.containerRegistry = containerRegistry;

            RegisterDialogWindows();

            RegisterStudentDialogs();
            RegisterSubjectDialogs();
            RegisterTeacherDialogs();
            RegisterExamDialogs();
            RegisterGroupDialogs();

        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthorizationModule>();
            moduleCatalog.AddModule<WorkspaceModule>();
        }

        private void RegisterDialogWindows()
        {
            containerRegistry.RegisterDialogWindow<AddDialogWindow>("AddDialogWindow");
            containerRegistry.RegisterDialogWindow<EditDialogWindow>("EditDialogWindow");
            containerRegistry.RegisterDialogWindow<RemoveDialogWindow>("RemoveDialogWindow");
        }

        private void RegisterLegacyDialogs()
        {
            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>();
            containerRegistry.RegisterDialog<DocsSettingsDialog, DocsSettingsDialogViewModel>();
        }

        private void RegisterSubjectDialogs()
        {
            containerRegistry.RegisterDialog<AddSubjectDialog, AddSubjectDialogViewModel>("AddSubjectDialog");
            containerRegistry.RegisterDialog<EditSubjectDialog, EditSubjectDialogViewModel>("EditSubjectDialog");
            containerRegistry.RegisterDialog<RemoveSubjectDialog, RemoveSubjectDialogViewModel>("RemoveSubjectDialog");
        }

        private void RegisterStudentDialogs()
        {
            containerRegistry.RegisterDialog<AddStudentDialog, AddStudentDialogViewModel>("AddStudentDialog");
            containerRegistry.RegisterDialog<EditStudentDialog, EditStudentDialogViewModel>("EditStudentDialog");
            containerRegistry.RegisterDialog<RemoveStudentDialog, RemoveStudentDialogViewModel>("RemoveStudentDialog");
        }

        private void RegisterTeacherDialogs()
        {
            containerRegistry.RegisterDialog<AddTeacherDialog, AddTeacherDialogViewModel>("AddTeacherDialog");
            containerRegistry.RegisterDialog<EditTeacherDialog, EditTeacherDialogViewModel>("EditTeacherDialog");
            containerRegistry.RegisterDialog<RemoveTeacherDialog, RemoveTeacherDialogViewModel>("RemoveTeacherDialog");
        }

        private void RegisterExamDialogs()
        {
            containerRegistry.RegisterDialog<AddExamDialog, AddExamDialogViewModel>("AddExamDialog");
            containerRegistry.RegisterDialog<EditExamDialog, EditExamDialogViewModel>("EditExamDialog");
            containerRegistry.RegisterDialog<RemoveExamDialog, RemoveExamDialogViewModel>("RemoveExamDialog");
        }
        private void RegisterGroupDialogs()
        {
            containerRegistry.RegisterDialog<AddFacultyDialog, AddGroupDialogViewModel>("AddGroupDialog");
            containerRegistry.RegisterDialog<EditFacultyDialog, EditGroupDialogViewModel>("EditGroupDialog");
            containerRegistry.RegisterDialog<RemoveFacultyDialog, RemoveGroupDialogViewModel>("RemoveGroupDialog");
        }
    }
}
