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
        protected override string AddDialogName { get; set; }
        protected override string EditDialogName { get; set; }
        protected override string RemoveDialogName { get; set; }

        public ExamsViewModel(IDialogService service, IRepository<Exam> repository) : base(service, repository)
        {
            this.repository.Searcher = new ExamSearcher();
            AddDialogName = "AddExamDialog";
            EditDialogName = "EditExamDialog";
            RemoveDialogName = "RemoveExamDialog";
        }
    }
}
