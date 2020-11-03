using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Workspace.DBHandler;

namespace Authorization.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private IRegionManager regionManager;
        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string username;
        public string Username
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public DelegateCommand LoginCommand { get; private set; }

        public LoginViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            LoginCommand = new DelegateCommand(Login);

        }
        private void Login()
        {
            var list = DataBase.GetUsers();
            foreach (var item in list)
            {
                if (Username?.ToString() == item.Username && Password?.ToString() == item.Password)
                {
                    Message = "Авторизация прошла успешно";
                    regionManager.RequestNavigate("ContentRegion", "Workspace");
                    break;
                }
            }
            Message = "Неверно введены данные";          
        }
    }
}
