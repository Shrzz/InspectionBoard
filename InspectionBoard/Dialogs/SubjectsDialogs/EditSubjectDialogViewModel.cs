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

namespace InspectionBoard.Dialogs.SubjectsDialogs
{
    public class EditSubjectDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly IDatabaseService<Subject> service;

        private Subject subject;
        public Subject Subject
        {
            get { return subject; }
            set { SetProperty(ref subject, value); }
        }

        private int selectedSubjectId;
        public int SelectedSubjectId
        {
            get { return selectedSubjectId; }
            set { SetProperty(ref selectedSubjectId, value); }
        }

        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(service.SelectIds());
        }

        public string Title => "Изменить сведения о предмете";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditSubjectDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new SubjectService();
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditSubject()
        {
            Subject.Id = SelectedSubjectId;
            await service.EditAsync(Subject);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await EditSubject();
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
            Subject = new Subject();
            SelectedSubjectId = Ids[0];
        }
    }
}
