using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Windows.SubjectsDialogs;
using Prism.Ioc;
using Prism.Modularity;
using Workspace.ViewModels;
using Workspace.Views;
using Workspace.Windows;

namespace Workspace
{
    public class WorkspaceModule : IModule
    {

        public void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialogWindow<AddDialogWindow>("AddDialogWindow");
            containerRegistry.RegisterDialogWindow<EditDialogWindow>("EditDialogWindow");
            containerRegistry.RegisterDialogWindow<RemoveDialogWindow>("RemoveDialogWindow");
            containerRegistry.RegisterDialogWindow<DescriptionDialogWindow>("DescriptionDialogWindow");

            containerRegistry.Register<IRepository<Teacher>, TeacherRepository>();
            containerRegistry.Register<IRepository<Student>, StudentRepository>();
            containerRegistry.Register<IRepository<Exam>, ExamRepository>();
            containerRegistry.Register<IRepository<Subject>, SubjectRepository>();
            containerRegistry.Register<IRepository<Group>, GroupRepository>();
            containerRegistry.Register<IRepository<Journal>, JournalRepository>();
            containerRegistry.Register<IRepository<Ticket>, TicketRepository>();
        }
    }
}