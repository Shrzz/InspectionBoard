using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.StudentsDialogs
{
    public class RemoveStudentDialogViewModel : RemoveDialogViewModel<Student, ExamContext>
    {
        public RemoveStudentDialogViewModel(StudentRepository repository) : base(repository)
        {

        }
    }
}
