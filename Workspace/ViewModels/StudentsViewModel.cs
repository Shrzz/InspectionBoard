using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.ViewModels
{
    public class StudentsViewModel : BindableBase
    {
        public ObservableCollection<Student> Students { get; }

        public StudentsViewModel()
        {
            Students = new ObservableCollection<Student>(Dbc.GetStudentList());
        }
    }
}
