using InspectionBoardLibrary.Database.Extensions;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.ExamsDialogs
{
    public class EditExamDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly IDatabaseService<Exam> service;

        private Exam exam;
        public Exam Exam
        {
            get { return exam; }
            set { SetProperty(ref exam, value); }
        }

        private int selectedExamId;
        public int SelectedExamId
        {
            get { return selectedExamId; }
            set { SetProperty(ref selectedExamId, value); }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set { SetProperty(ref date, value); }
        }

        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(service.SelectIds());
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

        public string Title => "Изменить сведения об экзамене";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditExamDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new ExamService();
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditExam()
        {
            Exam.Id = SelectedExamId;
            Exam.Date = Date.Date;
            await service.EditAsync(Exam);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await EditExam();
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
            SelectedExamId = Ids.FirstOrDefault();
            Exam.ExamForm = ExamForms.FirstOrDefault();
            Exam.ExamType = ExamTypes.FirstOrDefault();
            Exam.Student = Students.FirstOrDefault();
            Exam.Subject = Subjects.FirstOrDefault();
            Exam.Teacher = Teachers.FirstOrDefault();
            Date = DateTime.Today.Date;
        }
    }
}
