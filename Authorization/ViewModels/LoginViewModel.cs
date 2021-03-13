using InspectionBoardLibrary.DatabaseHandler;
using InspectionBoardLibrary.DataSeeder;
using InspectionBoardLibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Linq;

namespace Authorization.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
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

            using (UserContext context = new UserContext())
            {
                if (!context.Users.Any())
                {
                    DataSeeder seeder = new DataSeeder();
                    seeder.AddAdminUser();
                }
            }
        }

        private async void Login()
        {
            bool success = Dbc.TryLogin(Username, Password);
            if (success)
            {
                Message = "Авторизация прошла успешно";
                regionManager.RequestNavigate("ContentRegion", "Workspace");
            }
            else
            {
                Message = "Неверно введены данные";
            }
        }
    }
}
