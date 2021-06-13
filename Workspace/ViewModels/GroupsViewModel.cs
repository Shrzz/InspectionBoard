using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class GroupsViewModel : TablePage<Group, ExamContext>
    {
        protected override string AddDialogName { get; set; }
        protected override string EditDialogName { get; set; }
        protected override string RemoveDialogName { get; set; }

        public GroupsViewModel(IDialogService service, IRegionManager regionManager, IRepository<Group> repository) : base(service, regionManager, repository)
        {
            this.repository.Searcher = new GroupSearcher();
            AddDialogName = "AddGroupDialog";
            EditDialogName = "EditGroupDialog";
            RemoveDialogName = "RemoveGroupDialog";
            RegionName = "Groups";
        }
    }
}
