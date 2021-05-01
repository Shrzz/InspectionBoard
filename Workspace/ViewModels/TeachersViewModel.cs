using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Domain.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class TeachersViewModel : TablePage<Teacher, ExamContext>
    {
        public TeachersViewModel(IDialogService service, TeacherRepository repository, TeacherSearcher searcher) : base(service, repository, searcher)
        {

        }
    }
}
