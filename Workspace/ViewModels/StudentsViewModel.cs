using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Domain.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class StudentsViewModel : TablePage<Student, ExamContext>
    {
        public StudentsViewModel(IDialogService service, IRepository<Student> repository) : base(service, repository)
        {
            this.repository.Searcher = new StudentSearcher();
        }
    }
}
