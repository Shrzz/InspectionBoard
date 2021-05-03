using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class ExamsViewModel : TablePage<Exam, ExamContext>
    {
        public ExamsViewModel(IDialogService service, IRepository<Exam> repository) : base(service, repository)
        {
            this.repository.Searcher = new ExamSearcher();
        }
    }
}
