using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoard.Dialogs.ExamsDialogs
{
    public class RemoveExamDialogViewModel : RemoveDialogViewModel<Exam, ExamContext>
    {
        public RemoveExamDialogViewModel(ExamRepository repository) : base(repository)
        {

        }
    }
}
