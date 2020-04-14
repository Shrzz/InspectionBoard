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

        public ViewAViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            LoginCommand = new DelegateCommand(Login);

        }
        private void Login()
        {
            if (Username?.ToString() == "admin" && Password?.ToString() == "admin")
            {
                Message = "авторизован";
                regionManager.RequestNavigate("ContentRegion", "Workspace");
            }
            else
            {
                Message = "неверно введены данные";
            }
        }
    }
}
