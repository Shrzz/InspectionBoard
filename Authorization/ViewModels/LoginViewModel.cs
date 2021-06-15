using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.DataSeeder;
using InspectionBoardLibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Linq;
using Workspace.Views;

namespace Authorization.ViewModels
{
    public class LoginViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly LoginService service;
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
            this.service = new LoginService();
            LoginCommand = new DelegateCommand(Login);
        }

#pragma warning disable S3168 // "async" methods should not return "void"
        private async void Login()
#pragma warning restore S3168 // "async" methods should not return "void"
        {
            var user = await service.TryLogin(Username, Password);
            if (user != null)
            {
                ApplicationSettings.CurrentUser = user;
                Message = "Авторизация прошла успешно";
                regionManager.RequestNavigate("MainRegion", "MainMenu");
            }
            else
            {
                Message = "Введены неверные данные";
            }
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Message = "";
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
