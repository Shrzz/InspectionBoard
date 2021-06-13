﻿using InspectionBoardLibrary.Database.Contexts;
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

        private string message;
        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }

        public string Title => "Добавить пользователя";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddUserDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            repository = new UserRepository(new ExamContext());
        }

        public event Action<IDialogResult> RequestClose;

        private async Task<bool> AddUser()
        {
            if (User is null || User.Username is null || User.Password is null)
            {
                return false;
            }

            if (User.Username.Length < 1 || User.Password.Length < 1)
            {
                return false;
            }

            if ((repository as UserRepository).UsernameIsTaken(User.Username))
            {
                Message = "Пользователь с таким логином уже существует.";
                return false;
            }
            
            await repository.Add(User);
            return true;
        }

        protected virtual async void CloseDialog(string parameter)
        {
            Message = "";
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                bool success = await AddUser();
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
