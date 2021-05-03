using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
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
