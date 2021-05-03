using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class EditTeacherDialogViewModel : EditDialogViewModel<Teacher, ExamContext>
    {
        public EditTeacherDialogViewModel(TeacherRepository repository) : base(repository)
        {

        }
    }
}

