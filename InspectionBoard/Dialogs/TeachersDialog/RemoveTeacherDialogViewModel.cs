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

namespace InspectionBoard.Dialogs.TeachersDialog
{
    public class RemoveTeacherDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly IDatabaseService<Teacher> service;

        private int selectedSubjectId;
        public int SelectedTeacherId
        {
            get { return selectedSubjectId; }
            set { SetProperty(ref selectedSubjectId, value); }
        }
        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(service.SelectIds());
        }
        public string Title => "Удалить сведения о предмете";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public RemoveTeacherDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new TeacherService();
        }

        public event Action<IDialogResult> RequestClose;
        private async Task RemoveSubject()
        {
            await service.RemoveAsync(SelectedTeacherId);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await RemoveSubject();
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
