using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.Searchers;
using InspectionBoardLibrary.Models.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
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
