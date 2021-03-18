using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.TeachersDialog
{
    public class AddTeacherDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;

        private Teacher teacher;
        public Teacher Teacher
        {
            get { return teacher; }
            set { SetProperty(ref teacher, value); }
        }
        public string Title => "Добавить преподавателя";

        public AddTeacherDialogViewModel()
        {
            Teacher = new Teacher();
        }

        public event Action<IDialogResult> RequestClose;

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await TeacherService.AddAsync(Teacher);
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
        }
    }
}
