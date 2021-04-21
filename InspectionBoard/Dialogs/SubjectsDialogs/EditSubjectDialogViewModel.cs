using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoard.Dialogs.SubjectsDialogs
{
    public class EditSubjectDialogViewModel : EditDialogViewModel<Subject, ExamContext>
    {
        public EditSubjectDialogViewModel(SubjectRepository repository) : base(repository)
        {

        }
    }
}
