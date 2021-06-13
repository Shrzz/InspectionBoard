using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Dialogs.SettingsDialogs
{
    public class EditUserUsernameDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly UserRepository repository;

        private User user;
        public User User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        private string newUsername;
        public string NewUsername
        {
            get => newUsername;
            set { SetProperty(ref newUsername, value); }
        }

        private string message;
        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }



        public string Title => "Изменить логин пользователя";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditUserUsernameDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            repository = new UserRepository(new ExamContext());
        }

        public event Action<IDialogResult> RequestClose;

        private async Task<bool> EditUser()
        {
            if (User is null || User.Username is null || User.Password is null)
            {
                return false;
            }

            if (User.Username.Length < 1 || User.Password.Length < 1)
            {
                return false;
            }

            var user = (repository as UserRepository).GetUser(User.Username, User.Password);
            if (user == null)
            {
                Message = "Введённый пароль неверен, либо запрашиваемый пользователь не зарегистрирован.";
                return false;
            }

            user.Username = NewUsername;
            await repository.Update(user);
            return true;
        }

        protected virtual async void CloseDialog(string parameter)
        {
            Message = "";
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                var success = await EditUser();
                if (success == false) return;
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
