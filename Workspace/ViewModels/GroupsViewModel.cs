using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.Searchers;
using InspectionBoardLibrary.Models.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class GroupsViewModel : TablePage<Group, ExamContext>
    {
        public GroupsViewModel(IDialogService service, IRepository<Group> repository) : base(service, repository)
        {
            this.repository.Searcher = new GroupSearcher();
        }
    }
}
