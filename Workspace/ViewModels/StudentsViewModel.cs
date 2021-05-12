using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
using Prism.Services.Dialogs;
using System.ComponentModel;

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
