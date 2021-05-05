using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoardLibrary.Windows.SubjectsDialogs
{
    public class EditSubjectDialogViewModel : EditDialogViewModel<Subject, ExamContext>
    {
        public EditSubjectDialogViewModel(IRepository<Subject> repository) : base(repository)
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
