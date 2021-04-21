using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoard.Dialogs.TeachersDialog
{
    public class AddTeacherDialogViewModel : AddDialogViewModel<Teacher, ExamContext>
    {

        public AddTeacherDialogViewModel(TeacherRepository repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            this.Entity = new Teacher();
        }
    }
}
