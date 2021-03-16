using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.ViewModels
{
    public class TeachersViewModel : BindableBase
    {
        public ObservableCollection<Teacher> Teachers { get; }

        public TeachersViewModel()
        {
            Teachers = new ObservableCollection<Teacher>(Dbc.GetTeachersList());
        }
    }
}
