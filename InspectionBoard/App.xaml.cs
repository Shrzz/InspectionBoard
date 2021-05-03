using Authorization;
using InspectionBoard.Dialogs;
using InspectionBoard.Dialogs.ExamsDialogs;
using InspectionBoard.Dialogs.GroupsDialogs;
using InspectionBoard.Dialogs.SettingsDialogs;
using InspectionBoard.Dialogs.StudentsDialogs;
using InspectionBoard.Dialogs.SubjectsDialogs;
using InspectionBoard.Dialogs.TeachersDialog;
using InspectionBoard.ViewModels;
using InspectionBoard.Views;
using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using Prism.Unity;
using System.Collections.ObjectModel;
using System.Windows;
using Workspace;
using Workspace.ViewModels;
using Workspace.Views;

namespace InspectionBoard
{
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<Views.Main>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            RegisterStudentDialogs(containerRegistry);
            RegisterSubjectDialogs(containerRegistry);
            RegisterTeacherDialogs(containerRegistry);
            RegisterExamDialogs(containerRegistry);
            RegisterGroupDialogs(containerRegistry);
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

        private void RegisterExamDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddExamDialog, AddExamDialogViewModel>("AddExamDialog");
            containerRegistry.RegisterDialog<EditExamDialog, EditExamDialogViewModel>("EditExamDialog");
            containerRegistry.RegisterDialog<RemoveExamDialog, RemoveExamDialogViewModel>("RemoveExamDialog");
        }
        private void RegisterGroupDialogs(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<AddFacultyDialog, AddGroupDialogViewModel>("AddGroupDialog");
            containerRegistry.RegisterDialog<EditFacultyDialog, EditGroupDialogViewModel>("EditGroupDialog");
            containerRegistry.RegisterDialog<RemoveFacultyDialog, RemoveGroupDialogViewModel>("RemoveGroupDialog");
        }
    }
}
