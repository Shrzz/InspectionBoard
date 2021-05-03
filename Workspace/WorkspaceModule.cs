using Workspace.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Workspace.ViewModels;
using MaterialDesignThemes.Wpf;
using Prism.Mvvm;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Database.Contexts;
using System.Data.Entity;
using InspectionBoardLibrary.Database.Repositories;

namespace Workspace
{
    public class WorkspaceModule : IModule
    {

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRepository<Teacher>, TeacherRepository>();
            containerRegistry.Register<IRepository<Student>, StudentRepository>();
            containerRegistry.Register<IRepository<Exam>, ExamRepository>();
            containerRegistry.Register<IRepository<Subject>, SubjectRepository>();
            containerRegistry.Register<IRepository<Group>, GroupRepository>();

            //containerRegistry.RegisterForNavigation<Analysis, AnalysisViewModel>("Analyze");
            //containerRegistry.RegisterForNavigation<DocsEnrollment, DocsEnrollmentViewModel>("DocsEnrollment");

            containerRegistry.RegisterForNavigation<Main, MainViewModel>("Workspace");
            containerRegistry.RegisterForNavigation<Students, StudentsViewModel>("Students");
            containerRegistry.RegisterForNavigation<Teachers, TeachersViewModel>("Teachers");
            containerRegistry.RegisterForNavigation<Exams, ExamsViewModel>("Exams");
            containerRegistry.RegisterForNavigation<Subjects, SubjectsViewModel>("Subjects");
            containerRegistry.RegisterForNavigation<Groups, GroupsViewModel>("Groups");

            containerRegistry.RegisterDialog<NotificationDialog, NotificationDialogViewModel>("NotificationDialog");

        }
    }
}