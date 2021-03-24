using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.FacultiesDialogs
{
    public class AddFacultyDialogViewModel : BindableBase, IDialogAware
    {
        private IDatabaseService<Faculty> service;
        public string Title => "Добавить факультет";

        private Faculty faculty;
        public Faculty Faculty
        {
            get { return faculty; }
            set { SetProperty(ref faculty, value); }
        }

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddFacultyDialogViewModel()
        {
            service = new FacultyService();
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }
        private async Task AddFaculty()
        {
            await service.AddAsync(Faculty);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await AddFaculty();
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
            Faculty = new Faculty();
        }
    }
}
