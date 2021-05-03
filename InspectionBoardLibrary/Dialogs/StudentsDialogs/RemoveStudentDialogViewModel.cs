using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Windows.StudentsDialogs
{
    public class RemoveStudentDialogViewModel : RemoveDialogViewModel<Student, ExamContext>
    {
        public RemoveStudentDialogViewModel(StudentRepository repository) : base(repository)
        {

        }
    }
}
