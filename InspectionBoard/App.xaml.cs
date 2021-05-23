using Authorization;
using Documentation;
using InspectionBoard.ViewModels;
using InspectionBoard.Views;
using InspectionBoardLibrary.Dialogs.SettingsDialogs;
using InspectionBoardLibrary.Dialogs.StudentsDialogs;
using InspectionBoardLibrary.Dialogs.TicketsDialogs;
using InspectionBoardLibrary.Windows;
using InspectionBoardLibrary.Windows.ExamsDialogs;
using InspectionBoardLibrary.Windows.GroupsDialogs;
using InspectionBoardLibrary.Windows.SettingsDialogs;
using InspectionBoardLibrary.Windows.StudentsDialogs;
using InspectionBoardLibrary.Windows.SubjectsDialogs;
using InspectionBoardLibrary.Windows.TeachersDialog;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using Workspace;
using Workspace.Windows;

namespace InspectionBoardLibrary
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

            this.containerRegistry.RegisterForNavigation<Settings, SettingsViewModel>("Settings");
            RegisterDialogWindows();
            RegisterStudentDialogs();
            RegisterSubjectDialogs();
            RegisterTeacherDialogs();
            RegisterExamDialogs();
            RegisterGroupDialogs();
            RegisterTicketDialogs();

            this.containerRegistry.RegisterDialog<AddUserDialog, AddUserDialogViewModel>("AddUserDialog");
            this.containerRegistry.RegisterDialog<StudentDescriptionDialog, StudentDescriptionDialogViewModel>("StudentDescriptionDialog");
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<AuthorizationModule>();
            moduleCatalog.AddModule<WorkspaceModule>();
            moduleCatalog.AddModule<DocumentationModule>();
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

        private void RegisterTicketDialogs()
        {
            containerRegistry.RegisterDialog<AddTicketDialog, AddTicketDialogViewModel>("AddTicketDialog");
            containerRegistry.RegisterDialog<EditTicketDialog, EditTicketDialogViewModel>("EditTicketDialog");
            containerRegistry.RegisterDialog<RemoveTicketDialog, RemoveTicketDialogViewModel>("RemoveTicketDialog");
        }
    }
}
