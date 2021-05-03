using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
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
