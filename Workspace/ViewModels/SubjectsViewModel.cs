using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;

namespace Workspace.ViewModels
{
    public class SubjectsViewModel : BindableBase
    {
        private readonly IDialogService dialogService;
        public ObservableCollection<Subject> Subjects { get; }

        public SubjectsViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
            Subjects = new ObservableCollection<Subject>(Dbc.GetSubjectsList());
        }

        public DelegateCommand<string> ShowDialogCommand { get; private set; }

        private void ShowDialog(string dialogName)
        {
            dialogService.ShowDialog(dialogName, r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.None:
                        {
                            break;
                        }
                    case ButtonResult.OK:
                        {
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
