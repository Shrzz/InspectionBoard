using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoard.Dialogs.StudentsDialogs
{
    public class RemoveStudentDialogViewModel : RemoveDialogViewModel<Student, ExamContext>
    {
        public RemoveStudentDialogViewModel(StudentRepository repository) : base(repository)
        {

        }
    }
}
