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
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class EditExamDialogViewModel : EditDialogViewModel<Exam, ExamContext>
    {
        public EditExamDialogViewModel(IRepository<Exam> repository) : base(repository)
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

        public async override void OnDialogOpened(IDialogParameters parameters)
        {
            Entities = await repository.Select();
            Ids = await repository.SelectIds();
            Entity = await repository.SelectSingle(Ids.FirstOrDefault());
            if (Ids.Count > 0)
            {
                SelectedEntityId = Ids[0];
            }
            else
            {
                SelectedEntityId = -1;
            }

            Students = await (repository as ExamRepository).SelectStudents();
            Teachers = await (repository as ExamRepository).SelectTeachers();
            Subjects = await (repository as ExamRepository).SelectSubjects();
            ExamForms = Enum.GetValues(typeof(ExamForm)).Cast<ExamForm>().ToList();
            ExamTypes = Enum.GetValues(typeof(ExamType)).Cast<ExamType>().ToList();
        }

        public override void CloseDialog(string parameter)
        {
            Entity.Date = Date;
            base.CloseDialog(parameter);
        }
    }
}