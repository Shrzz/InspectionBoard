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
        // entity properties
        private Subject subject;
        public Subject Subject { get => subject; set => SetProperty(ref subject, value); }

        private Teacher teacher;
        public Teacher Teacher { get => teacher; set => SetProperty(ref teacher, value); }

        private Student student;
        public Student Student { get => student; set => SetProperty(ref student, value); }

        private Ticket ticket;
        public Ticket Ticket { get => ticket; set => SetProperty(ref ticket, value); }

        private DateTime date;
        public DateTime Date { get => date; set => SetProperty(ref date, value); }

        private ExamType examType;
        public ExamType ExamType { get => examType; set => SetProperty(ref examType, value); }

        private ExamForm examForm;
        public ExamForm ExamForm { get => examForm; set => SetProperty(ref examForm, value); }


        // values collections
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

        private byte mark;
        public byte Mark
        {
            get => mark;
            set { SetProperty(ref mark, value); }
        }

        public AddExamDialogViewModel(IRepository<Exam> repository) : base(repository)
        {

        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;

            Students = await (repository as ExamRepository).SelectStudents();
            Teachers = await (repository as ExamRepository).SelectTeachers();
            Subjects = await (repository as ExamRepository).SelectSubjects();
            ExamForms = Enum.GetValues(typeof(ExamForm)).Cast<ExamForm>().ToList();
            ExamTypes = Enum.GetValues(typeof(ExamType)).Cast<ExamType>().ToList();

            Mark = 0;
            Entity = new Exam();
            Entity.Student = Students.FirstOrDefault();
            Entity.Teacher = Teachers.FirstOrDefault();
            Entity.Subject = Subjects.FirstOrDefault();
            (repository as ExamRepository).GetStudentsSet().Attach(Entity.Student);
            (repository as ExamRepository).GetSubjectsSet().Attach(Entity.Subject);
            (repository as ExamRepository).GetTEachersSet().Attach(Entity.Teacher);
            Entity.ExamForm = ExamForm.Письменный;
            Entity.ExamType = ExamType.Промежуточный;
            Date = DateTime.Today.Date;
        }

        public async override void CloseDialog(string parameter)
        {
            Entity.Date = Date;
            base.CloseDialog(parameter);
            ExamContext a = new ExamContext();
            Journal j = new Journal();
            j.Student = Entity.Student;
            j.Subject = Entity.Subject;
            j.Date = Entity.Date.Value;
            j.Mark = Mark;
            a.Journals.Add(new Journal());
        }
    }
}
