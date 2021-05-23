using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace InspectionBoardLibrary.Windows.SubjectsDialogs
{
    public class AddSubjectDialogViewModel : AddDialogViewModel<Subject, ExamContext>
    {
        private string name;
        public string Name { get => name; set { SetProperty(ref name, value); } }

        private int lectoryHours;
        public int LectoryHours { get => lectoryHours; set { SetProperty(ref lectoryHours, value); } }

        private int laboratoryHours;
        public int LaboratoryHours { get => laboratoryHours; set { SetProperty(ref laboratoryHours, value); } }

        public AddSubjectDialogViewModel(IRepository<Subject> repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;

        }

        public override void CloseDialog(string parameter)
        {
            Entity = new Subject();
            Entity.Name = Name;
            Entity.LectoryHours = LectoryHours;
            Entity.LaboratoryHours = LaboratoryHours;
            base.CloseDialog(parameter);
        }
    }
}
