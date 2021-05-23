using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class StudentsViewModel : TablePage<Student, ExamContext>
    {
        protected override string AddDialogName { get; set; }
        protected override string EditDialogName { get; set; }
        protected override string RemoveDialogName { get; set; }

        public StudentsViewModel(IDialogService service, IRepository<Student> repository) : base(service, repository)
        {
            this.repository.Searcher = new StudentSearcher();
            AddDialogName = "AddStudentDialog";
            EditDialogName = "EditStudentDialog";
            RemoveDialogName = "RemoveStudentDialog";
        }
    }
}
