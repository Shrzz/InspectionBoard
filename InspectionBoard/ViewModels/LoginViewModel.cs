using InspectionBoard.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace InspectionBoard.ViewModels
{
    public class LoginViewModel : ViewModel
    {
        public event EventHandler<LoginEventArgs> OnAuthorize;

        public ICommand LoginCommand { get; }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Authorize);
        }

        private string user;
        public string User
        {
            get => user;
            set => Set(ref user, value);
        }

        private string password;
        public string Password
        {
            get => password;
            set => Set(ref password, value);
        }

        private string message;
        public string Message
        {
            get => message;
            set => Set(ref message, value);
        }

        private void Authorize()
        {
            if (User?.ToString() == "admin" && Password?.ToString() == "admin")
            {
                OnAuthorize?.Invoke(this, new LoginEventArgs(User, true, "Авторизация прошла успешно"));
            }
            else
            {
                OnAuthorize?.Invoke(this, new LoginEventArgs(User, false, "Введены неверные данные"));
            }
        }
    }
}
