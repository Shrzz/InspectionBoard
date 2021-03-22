using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Database.Extensions;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Commands;

namespace InspectionBoard.Dialogs.ExamsDialogs
{
    public class AddExamDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly IDatabaseService<Exam> service;

        private Exam exam;
        public Exam Exam
        {
            get { return exam; }
            set { SetProperty(ref exam, value); }
        }
        public ObservableCollection<ExamForm> ExamForms
        {
            get => new ObservableCollection<ExamForm>((service as ExamService).SelectExamForms());
        }
        public ObservableCollection<ExamType> ExamTypes
        {
            get => new ObservableCollection<ExamType>((service as ExamService).SelectExamTypes());
        }

        public ObservableCollection<Student> Students
        {
            get => new ObservableCollection<Student>((service as ExamService).SelectStudents());
        }

        public ObservableCollection<Teacher> Teachers
        {
            get => new ObservableCollection<Teacher>((service as ExamService).SelectTeachers());
        }

        public ObservableCollection<Subject> Subjects
        {
            get => new ObservableCollection<Subject>((service as ExamService).SelectSubjects());
        }

        public string Title => "Добавить студента";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddExamDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new ExamService();
        }

        public event Action<IDialogResult> RequestClose;

        private async Task AddExam()
        {
            await service.AddAsync(Exam);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await AddExam();
                result = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
            {
                result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Exam = new Exam();
            Exam.ExamForm = ExamForms.FirstOrDefault();
            Exam.ExamType = ExamTypes.FirstOrDefault();
            Exam.Student = Students.FirstOrDefault();
            Exam.Subject = Subjects.FirstOrDefault();
            Exam.Teacher = Teachers.FirstOrDefault();
        }
    }
}
