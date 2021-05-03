using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoard.Dialogs.ExamsDialogs
{
    public class AddExamDialogViewModel : AddDialogViewModel<Exam, ExamContext>
    {
        public AddExamDialogViewModel(ExamRepository repository) : base(repository)
        {

        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public List<string> ExamForms
        {
            get => new List<string>(Enum.GetNames(typeof(ExamForm)));
        }

        public List<string> ExamTypes
        {
            get => new List<string>(Enum.GetNames(typeof(ExamType)));
        }

        public ObservableCollection<Student> Students
        {
            get => (repository as ExamRepository).SelectStudents().Result;
        }

        public ObservableCollection<Teacher> Teachers
        {
            get => (repository as ExamRepository).SelectTeachers().Result;
        }

        public ObservableCollection<Subject> Subjects
        {
            get => (repository as ExamRepository).SelectSubjects().Result;
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Entity = new Exam();
            Entity.Student = Students.FirstOrDefault();
            Entity.Teacher = Teachers.FirstOrDefault();
            Date = DateTime.Today.Date;
        }
    }
}
