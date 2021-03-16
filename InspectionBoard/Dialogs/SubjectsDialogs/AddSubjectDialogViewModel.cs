using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.SubjectsDialogs
{
    public class AddSubjectDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;

        private Subject subject;
        public Subject Subject
        {
            get { return subject; }
            set { SetProperty(ref subject, value); }
        }

        public string Title => "Добавить предмет";
    
        public AddSubjectDialogViewModel()
        {
            Subject = new Subject();
        }

        public event Action<IDialogResult> RequestClose;

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await Dbc.AddSubject(Subject);
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
