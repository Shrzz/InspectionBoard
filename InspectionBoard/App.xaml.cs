using InspectionBoard.Domain;
using InspectionBoard.ViewModels;
using InspectionBoard.Views;
using System;
using System.Windows;

namespace InspectionBoard
{
    public partial class App : Application
    {
        private MainView MainView { get; set; }
        private LoginView LoginView { get; set; }
        public MainViewModel MainViewModel { get; set; }
        public LoginViewModel LoginViewModel { get; set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
           /* LoginViewModel = new LoginViewModel();
            LoginView = new LoginView { DataContext = LoginViewModel };
            LoginViewModel.OnAuthorize += LoginViewModelOnOnAuthorize;
            LoginView.Show();*/
            MainViewModel = new MainViewModel();
            MainView = new MainView { DataContext = MainViewModel };
            MainViewModel.OnClosing += MainViewOnOnClosing;
            MainView.Show();
        }

        private void LoginViewModelOnOnAuthorize(object sender, LoginEventArgs e)
        {
            if (e.IsAuthorized)
            {
                MainView = new MainView { DataContext = MainViewModel };
                LoginView.Close();
                MainView.Show();
                return;
            }
            LoginViewModel.Message = e.Message;
        }

        private void MainViewOnOnClosing(object sender, ExitEventArgs e)
        {
            Current.Shutdown();
        }
    }
}
