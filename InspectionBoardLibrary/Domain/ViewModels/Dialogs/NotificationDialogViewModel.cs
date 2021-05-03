using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.ViewModels.Dialogs
{
    public class NotificationDialogViewModel : BindableBase, IDialogAware
    {
        private string message;
        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }
        public string Title => "NotificationDialog";

        public NotificationDialogViewModel()
        {
            Message = "WARNING";
        }

        public event Action<IDialogResult> RequestClose;

        private DelegateCommand<string> closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand => closeDialogCommand ?? (closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        protected void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter.ToLower() == "true")
            {
                result = ButtonResult.OK;
            }
            else
            {
                result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult result)
        {
            RequestClose?.Invoke(result);
        }

        public bool CanCloseDialog() => true;
        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
    }
}
