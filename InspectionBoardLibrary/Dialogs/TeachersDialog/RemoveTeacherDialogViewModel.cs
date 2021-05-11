using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.TeachersDialog
{
    public class RemoveTeacherDialogViewModel : RemoveDialogViewModel<Teacher, ExamContext>
    {
        public RemoveTeacherDialogViewModel(TeacherRepository repository) : base(repository)
        {

        }

        public async override void CloseDialog(string parameter)
        {
            ExamService service = new ExamService();
            if (await service.HasTeacherEntries(SelectedEntityId))
            {
                await service.RemoveAllTeacherEntries(SelectedEntityId);
            }

            base.CloseDialog(parameter);
        }
    }
}
