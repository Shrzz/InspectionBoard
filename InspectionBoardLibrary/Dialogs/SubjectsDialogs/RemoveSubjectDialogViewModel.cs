using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Dialogs;
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
