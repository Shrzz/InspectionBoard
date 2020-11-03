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
    public class EditApplicantDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private string title = "Добавить абитуриента";
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string[] parameters;
        public string[] Parameters
        {
            get { return parameters; }
            set { SetProperty(ref parameters, value); }
        }

        private int id;
        public int ID
        {
            get { return id; }
            set { SetProperty(ref id, value); }
        }

        private List<Applicant> applicants;
        public List<Applicant> Applicants
        {
            get { return applicants; }
            set
            {
                SetProperty(ref applicants, value);


            }
        }

        public event Action<IDialogResult> RequestClose;

        public EditApplicantDialogViewModel()
        {
            Parameters = new string[6];
            Applicants = new List<Applicant>(DataBase.GetApplicants());
        }

        protected virtual void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                Applicant applicant = new Applicant(ID, parameters[1], parameters[2], parameters[3], parameters[4], parameters[5]);
                EditApplicant(applicant);
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

        public virtual void OnDialogOpened(IDialogParameters parameters)        //удалить потом
        {
        }

        private void EditApplicant(Applicant a)
        {
            DataBase.EditApplicant(a);
        }
    }
}
