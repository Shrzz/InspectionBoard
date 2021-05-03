using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.Searchers;
using InspectionBoardLibrary.Models.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class TeachersViewModel : TablePage<Teacher, ExamContext>
    {
        public TeachersViewModel(IDialogService service, IRepository<Teacher> repository) : base(service, repository)
        {
            this.repository.Searcher = new TeacherSearcher();
        }
    }
}
