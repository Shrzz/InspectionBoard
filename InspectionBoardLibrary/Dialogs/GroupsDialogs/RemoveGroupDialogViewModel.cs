using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.GroupsDialogs
{
    public class RemoveGroupDialogViewModel : RemoveDialogViewModel<Group, ExamContext>
    {
        public RemoveGroupDialogViewModel(IRepository<Group> repository) : base(repository)
        {

        }
    }

}
