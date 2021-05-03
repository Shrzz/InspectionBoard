using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.TeachersDialog
{
    public class RemoveTeacherDialogViewModel : RemoveDialogViewModel<Teacher, ExamContext>
    {
        public RemoveTeacherDialogViewModel(TeacherRepository repository) : base(repository)
        {

        }
    }
}
