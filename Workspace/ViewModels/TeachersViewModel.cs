using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Searchers;
using Prism.Regions;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class TeachersViewModel : TablePage<Teacher, ExamContext>
    {
        protected override string AddDialogName { get; set; }
        protected override string EditDialogName { get; set; }
        protected override string RemoveDialogName { get; set; }

        public TeachersViewModel(IDialogService service, IRegionManager regionManager, IRepository<Teacher> repository) : base(service, regionManager, repository)
        {
            this.repository.Searcher = new TeacherSearcher();
            AddDialogName = "AddTeacherDialog";
            EditDialogName = "EditTeacherDialog";
            RemoveDialogName = "RemoveTeacherDialog";
            RegionName = "Teachers";
        }
    }
}
