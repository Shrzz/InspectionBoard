using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Services;
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
        public async override void CloseDialog(string parameter)
        {
            ExamService service = new ExamService();
            if (await service.HasSubjectEntries(SelectedEntityId))
            {
                await service.RemoveAllSubjectEntries(SelectedEntityId);
            }

            base.CloseDialog(parameter);
        }
    }
}
