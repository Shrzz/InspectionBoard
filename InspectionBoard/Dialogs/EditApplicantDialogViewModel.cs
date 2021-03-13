using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace InspectionBoard.Dialogs
{
    public class EditApplicantDialogViewModel : BindableBase, IDialogAware
    {
        private DelegateCommand<string> _closeDialogCommand;
        public DelegateCommand<string> CloseDialogCommand =>
            _closeDialogCommand ?? (_closeDialogCommand = new DelegateCommand<string>(CloseDialog));

        private string title = "Добавить студента";
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

        private List<Student> students;
        public List<Student> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
        }

        public event Action<IDialogResult> RequestClose;

        public EditApplicantDialogViewModel()
        {
            Parameters = new string[6];
            // изменить число параметров
            Students = Dbc.GetStudentList();
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;

            if (parameter?.ToLower() == "true")
            {
                Student student = new Student();
                // проинициализировать поля
                await Dbc.EditStudent(student);
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
    }
}
