using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoardLibrary.Windows.SubjectsDialogs
{
    public class AddSubjectDialogViewModel : AddDialogViewModel<Subject, ExamContext>
    {
        public AddSubjectDialogViewModel(IRepository<Subject> repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;
            Entity = new Subject();
        }
    }
}
