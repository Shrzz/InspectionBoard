using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.Searchers;
using InspectionBoardLibrary.Models.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class SubjectsViewModel : TablePage<Subject, ExamContext>
    {
        public SubjectsViewModel(IDialogService service, IRepository<Subject> repository) : base(service, repository)
        {
            this.repository.Searcher = new SubjectSearcher();
        }
    }
}
