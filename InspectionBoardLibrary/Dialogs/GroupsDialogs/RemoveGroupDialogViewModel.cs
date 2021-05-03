using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.GroupsDialogs
{
    public class RemoveGroupDialogViewModel : RemoveDialogViewModel<Group, ExamContext>
    {
        public RemoveGroupDialogViewModel(GroupRepository repository) : base(repository)
        {

        }
    }

}
