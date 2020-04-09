using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.ViewModels
{
    public class AuthorizationViewModel : BindableBase
    {
        private string login;
        public string Login
        {
            get { return login; }
            set { SetProperty(ref login, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public DelegateCommand AuthorizeCommand;

        public AuthorizationViewModel()
        {
            AuthorizeCommand = new DelegateCommand(Authorize);
        }

        private void Authorize()
        {
            if ((Login?.ToString() == "admin") && (Password?.ToString() == "admin"))
            {

            }else
            {
                Message = "Введены неверные данные";
            }
        }
    }
}
