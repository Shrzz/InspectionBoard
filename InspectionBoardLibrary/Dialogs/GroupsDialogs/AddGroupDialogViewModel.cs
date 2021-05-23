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
        private string name;
        public string Name { get => name; set => SetProperty(ref name, value); }

        private string faculty;
        public string Faculty { get => faculty; set => SetProperty(ref faculty, value); }

        public AddGroupDialogViewModel(IRepository<Group> repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;
        }

        public override void CloseDialog(string parameter)
        {
            Entity = new Group();
            Entity.Name = Name;
            Entity.Faculty = Faculty;

            base.CloseDialog(parameter);
        }
    }
}
