using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class AddExamDialogViewModel : AddDialogViewModel<Exam, ExamContext>
    {
        public AddExamDialogViewModel(IRepository<Exam> repository) : base(repository)
        {

        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public List<ExamForm> ExamForms
        {
            get => Enum.GetValues(typeof(ExamForm)).Cast<ExamForm>().ToList();
        }

        public List<ExamType> ExamTypes
        {
            get => Enum.GetValues(typeof(ExamType)).Cast<ExamType>().ToList();
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get => students;
            set { SetProperty(ref students, value); }
        }

        private ObservableCollection<Teacher> teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get => teachers;
            set { SetProperty(ref teachers, value); }
        }

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get => subjects;
            set { SetProperty(ref subjects, value); }
        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            Students = await (repository as ExamRepository).SelectStudents();
            Teachers = await (repository as ExamRepository).SelectTeachers();
            Subjects = await (repository as ExamRepository).SelectSubjects();
            Entity = new Exam();
            //Entity.Student = Students.FirstOrDefault();
            //Entity.Teacher = Teachers.FirstOrDefault();
            Date = DateTime.Today.Date;
        }
    }
}
