using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Windows.SettingsDialogs
{
    public class AddUserDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly UserRepository repository;

        private User user;
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public string Title => "Добавить пользователя";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddUserDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            repository = new UserRepository(new UserContext());
        }

        public event Action<IDialogResult> RequestClose;

        private async Task AddUser()
        {
            await repository.Add(User);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await AddUser();
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
            User = new User();
        }
    }
}
