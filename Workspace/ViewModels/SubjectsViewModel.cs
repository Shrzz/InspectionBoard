using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class SubjectsViewModel : TablePage<Subject, ExamContext>
    {
        protected override string AddDialogName { get; set; }
        protected override string EditDialogName { get; set; }
        protected override string RemoveDialogName { get; set; }

        public SubjectsViewModel(IDialogService service, IRepository<Subject> repository) : base(service, repository)
        {
            this.repository.Searcher = new SubjectSearcher();
            AddDialogName = "AddSubjectDialog";
            EditDialogName = "EditSubjectDialog";
            RemoveDialogName = "RemoveSubjectDialog";
        }
    }
}
