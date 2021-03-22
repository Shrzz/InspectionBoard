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

namespace InspectionBoard.Dialogs.RetakesDialogs
{
    public class EditRetakeDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly IDatabaseService<Retake> service;

        private Retake retake;
        public Retake Retake
        {
            get { return retake; }
            set { SetProperty(ref retake, value); }
        }

        private int selectedRetakeId;
        public int SelectedRetakeId
        {
            get { return selectedRetakeId; }
            set { SetProperty(ref selectedRetakeId, value); }
        }

        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(service.SelectIds());
        }

        public ObservableCollection<Student> Students
        {
            get => new ObservableCollection<Student>((service as RetakeService).SelectStudents());
        }

        public ObservableCollection<Teacher> Teachers
        {
            get => new ObservableCollection<Teacher>((service as RetakeService).SelectTeachers());
        }

        public ObservableCollection<Subject> Subjects
        {
            get => new ObservableCollection<Subject>((service as RetakeService).SelectSubjects());
        }

        public string Title => "Изменить сведения о пересдаче";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditRetakeDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new RetakeService();
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditRetake()
        {
            Retake.Id = SelectedRetakeId;
            await service.EditAsync(Retake);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await EditRetake();
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
            Retake = new Retake();
            SelectedRetakeId = Ids.FirstOrDefault();
            Retake.Student = Students.FirstOrDefault();
            Retake.Subject = Subjects.FirstOrDefault();
            Retake.Teacher = Teachers.FirstOrDefault();
        }
    }
}
