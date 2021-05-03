using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class EditExamDialogViewModel : EditDialogViewModel<Exam, ExamContext>
    {
        public EditExamDialogViewModel(IRepository<Exam> repository) : base(repository)
        {

        }

        public ObservableCollection<Exam> Entities { get; set; }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            var entities = new ObservableCollection<Exam>();
            parameters.TryGetValue("Entities", out entities);
            if (entities == null)
            {
                RaiseRequestClose(new DialogResult(ButtonResult.Abort));
                return;
            }

            SelectedEntityId = 0;
            Entities = entities;
            Entity = Entities[SelectedEntityId];
        }
    }
}