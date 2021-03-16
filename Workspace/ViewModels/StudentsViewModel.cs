using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Workspace.ViewModels
{
    public class StudentsViewModel : BindableBase
    {
        public ObservableCollection<Student> Students { get; set; }

        public StudentsViewModel()
        {
            Students = new ObservableCollection<Student>(Dbc.GetStudentList());
        }

        public async void Students_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    {
                        Student s = e.NewItems as Student;
                        if (s != null)
                        {
                            await Dbc.AddStudent(s);
                        }
                        break;
                    }
                case NotifyCollectionChangedAction.Remove:
                    {
                        break;
                    }
                case NotifyCollectionChangedAction.Replace:
                    {
                        break;
                    }
            }
        }


        
    }
}
