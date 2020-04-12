using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Authorization.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private IRegionManager _regionManager;
        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public DelegateCommand LoginCommand { get; private set; }

        public ViewAViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            LoginCommand = new DelegateCommand(Login);

        }

        private void Login()
        {
            if (Username?.ToString() == "admin" && Password?.ToString() == "admin")
            {
                Message = "авторизован";
                _regionManager.RequestNavigate("ContentRegion","Workspace");
            }
            else
            {
                Message = "неверно введены данные";
            }
        }
    }
}
