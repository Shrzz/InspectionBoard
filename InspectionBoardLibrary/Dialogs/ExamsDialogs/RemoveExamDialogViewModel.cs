using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class RemoveExamDialogViewModel : RemoveDialogViewModel<Exam, ExamContext>
    {
        public RemoveExamDialogViewModel(ExamRepository repository) : base(repository)
        {

        }
    }
}
