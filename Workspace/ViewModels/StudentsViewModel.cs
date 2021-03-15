using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.GridModels;
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
        public ObservableCollection<GridStudent> Students { get; set; }

        public StudentsViewModel()
        {
            Students = new ObservableCollection<GridStudent>();
            var l = Dbc.GetStudentList();
            foreach (var item in l)
            {
                GridStudent s = new GridStudent();
                s.Id = item.Id;
                s.Surname = item.Surname;
                s.Name = item.Name;
                s.Patronymic = item.Patronymic;
                s.Faculty = item.Faculty.Name;
                Students.Add(s);
            }

            Students.CollectionChanged += Students_CollectionChanged;
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
