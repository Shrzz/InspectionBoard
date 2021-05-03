using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.SubjectsDialogs
{
    public class RemoveSubjectDialogViewModel : RemoveDialogViewModel<Subject, ExamContext>
    {
        public RemoveSubjectDialogViewModel(IRepository<Subject> repository) : base(repository)
        {

        }
    }
}
