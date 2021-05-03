using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private string message;
        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }

        private IDialogService dialogService;

        public MainViewModel(IDialogService dialogService)
        {
            Message = "message";
            this.dialogService = dialogService;
            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
        }

        public DelegateCommand<string> ShowDialogCommand { get; set; }

        public void ShowDialog(string name)
        {
            var param = new DialogParameters();
            var s = new Student();
            s.Name = "Имя";
            param.Add("Entity", s);
            dialogService.ShowDialog(name, param, r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Message = "OK";
                }
                else
                {
                    Message = "Not OK";
                }
            }, "AddDialogWindow");
        }

    }
}
