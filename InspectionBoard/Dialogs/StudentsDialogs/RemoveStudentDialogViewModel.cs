using InspectionBoardLibrary.Database.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.StudentsDialogs
{
    public class RemoveStudentDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;

        private int selectedStudentId;
        public int SelectedStudentId
        {
            get { return selectedStudentId; }
            set { SetProperty(ref selectedStudentId, value); }
        }
        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(StudentService.SelectIds());
        }
        public string Title => "Удалить данные студента";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public RemoveStudentDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public event Action<IDialogResult> RequestClose;
        private async Task RemoveStudent()
        {
            await StudentService.RemoveAsync(SelectedStudentId);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await RemoveStudent();
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
        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
        }
    }
}
