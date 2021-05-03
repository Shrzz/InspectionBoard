using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoard.Dialogs.ExamsDialogs
{
    public class EditExamDialogViewModel : EditDialogViewModel<Exam, ExamContext>
    {
        public EditExamDialogViewModel(ExamRepository repository) : base(repository)
        {

        }

        
    }
}