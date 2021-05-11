using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.StudentsDialogs
{
    public class RemoveStudentDialogViewModel : RemoveDialogViewModel<Student, ExamContext>
    {

        public RemoveStudentDialogViewModel(IRepository<Student> repository) : base(repository)
        {

        }

        public async override void CloseDialog(string parameter)
        {
            ExamService service = new ExamService();
            if (await service.HasStudentEntries(SelectedEntityId))
            {
                await service.RemoveAllStudentEntries(SelectedEntityId);
            }

            base.CloseDialog(parameter);
        }
    }
}
