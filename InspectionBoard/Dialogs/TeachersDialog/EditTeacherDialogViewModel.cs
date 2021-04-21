using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoard.Dialogs.ExamsDialogs
{
    public class EditTeacherDialogViewModel : EditDialogViewModel<Teacher, ExamContext>
    {
        public EditTeacherDialogViewModel(TeacherRepository repository) : base(repository)
        {

        }
    }
}

