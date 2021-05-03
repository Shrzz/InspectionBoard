using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoard.Dialogs.SubjectsDialogs
{
    public class EditSubjectDialogViewModel : EditDialogViewModel<Subject, ExamContext>
    {
        public EditSubjectDialogViewModel(SubjectRepository repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
        }
    }
}
