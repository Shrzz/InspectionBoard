using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoardLibrary.Windows.GroupsDialogs
{
    public class AddGroupDialogViewModel : AddDialogViewModel<Group, ExamContext>
    {
        public AddGroupDialogViewModel(IRepository<Group> repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Entity = new Group();
        }
    }
}
