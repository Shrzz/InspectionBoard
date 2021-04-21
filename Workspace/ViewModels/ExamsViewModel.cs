using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Domain.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class ExamsViewModel : TablePage<Exam, ExamContext>
    {
        public ExamsViewModel(DialogService service, ExamRepository repository, ExamSearcher searcher) : base(service, repository, searcher)
        {

        }
    }
}
