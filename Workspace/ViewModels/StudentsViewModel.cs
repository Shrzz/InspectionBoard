using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Workspace.ViewModels
{
    public class StudentsViewModel : BindableBase
    {
        private readonly IDialogService dialogService;
        public ObservableCollection<Student> Students { get; private set; }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set { SetProperty(ref searchKeyword, value); }
        }

        public StudentsViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
            Students = new ObservableCollection<Student>(StudentService.Select());
        }

        public DelegateCommand<string> ShowDialogCommand { get; private set; }

        private void ShowDialog(string dialogName)
        {
            dialogService.ShowDialog(dialogName, new DialogParameters(), r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.None:
                        {
                            break;
                        }
                    case ButtonResult.OK:
                        {
                            Students = new ObservableCollection<Student>(StudentService.Select());
                            break;
                        }
                    case ButtonResult.Cancel:
                        {
                            break;
                        }
                }
            });
        }
    }
}
