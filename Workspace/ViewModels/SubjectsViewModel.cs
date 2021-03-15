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
    public class SubjectsViewModel : BindableBase
    {
        public ObservableCollection<Subject> Subject { get; }

        public SubjectsViewModel()
        {
            Subject = new ObservableCollection<Subject>(Dbc.GetSubjectsList());
        }
    }
}
