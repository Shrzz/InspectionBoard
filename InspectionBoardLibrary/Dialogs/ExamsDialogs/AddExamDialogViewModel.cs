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

        private IList<ExamForm> examForms;
        public IList<ExamForm> ExamForms
        {
            get => examForms;
            set { SetProperty(ref examForms, value); }
        }

        public IList<ExamType> examTypes;
        public IList<ExamType> ExamTypes
        {
            get => examTypes;
            set { SetProperty(ref examTypes, value); }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            Students = await (repository as ExamRepository).SelectStudents();
            Teachers = await (repository as ExamRepository).SelectTeachers();
            Subjects = await (repository as ExamRepository).SelectSubjects();
            ExamForms = Enum.GetValues(typeof(ExamForm)).Cast<ExamForm>().ToList();
            ExamTypes = Enum.GetValues(typeof(ExamType)).Cast<ExamType>().ToList();

            Entity = new Exam();
            Entity.Student = Students.FirstOrDefault();
            Entity.Teacher = Teachers.FirstOrDefault();
            Entity.Subject = Subjects.FirstOrDefault();
            Entity.ExamForm = ExamForm.Письменный;
            Entity.ExamType = ExamType.Промежуточный;
            Date = DateTime.Today.Date;
        }
    }
}
