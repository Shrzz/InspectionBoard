using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoardLibrary.Windows.SubjectsDialogs
{
    public class EditSubjectDialogViewModel : EditDialogViewModel<Subject, ExamContext>
    {
        public EditSubjectDialogViewModel(IRepository<Subject> repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
        }
    }
}
