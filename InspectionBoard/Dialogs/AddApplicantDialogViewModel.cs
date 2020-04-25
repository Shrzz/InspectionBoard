using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.DBHandler;
using Workspace.Models;

namespace InspectionBoard.Dialogs
{
    public class AddApplicantDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private string _speciality;
        public string Speciality
        {
            get { return _speciality; }
            set { SetProperty(ref _speciality, value); }
        }

        private string title = "Добавить абитуриента";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private Applicant applicant;
        public Applicant Applicant
        {
            get { return applicant; }
            set { SetProperty(ref applicant, value); }
        }


        public event Action<IDialogResult> RequestClose;

        public AddApplicantDialogViewModel()
        {
            applicant = new Applicant();
        }

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            AddApplicant();
            if (parameter?.ToLower() == "true")
            {
                result = ButtonResult.OK;

            }
            else
            {
                if (parameter?.ToLower() == "false")
                    result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            Speciality = parameters.GetValue<string>("message");
        }

        private void AddApplicant()
        {
            Applicant a = new Applicant(1, "name1", "location1", "bd1", "mark1", "spec1");
            DataBase.AddApplicant("spec1", a);
        }
    }
}
