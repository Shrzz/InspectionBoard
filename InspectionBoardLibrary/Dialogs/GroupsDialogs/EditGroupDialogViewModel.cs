using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class EditGroupDialogViewModel : EditDialogViewModel<Group, ExamContext>
    {
        public EditGroupDialogViewModel(IRepository<Group> repository) : base(repository)
        {

        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            Entities = await repository.Select(); 
            Entity = await repository.SelectFirst(); 
            Ids = await repository.SelectIds();
        }
    }
}
