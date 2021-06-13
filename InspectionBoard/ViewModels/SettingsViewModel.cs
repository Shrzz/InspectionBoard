using InspectionBoardLibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.ViewModels
{
    public class SettingsViewModel : BindableBase, INavigationAware, IDialogAware
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;
        public SettingsViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            ShowAddUserDialogCommand = new DelegateCommand(ShowAddUserDialog);
            ShowEditUserDialogCommand = new DelegateCommand(ShowEditUserDialog);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private string username;

        public event Action<IDialogResult> RequestClose;
        public DelegateCommand ShowAddUserDialogCommand { get; private set; }
        public DelegateCommand ShowEditUserDialogCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public string Username
        {
            get => username;
            set { SetProperty(ref username, value); }
        }

        public string Title => throw new NotImplementedException();

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (String.IsNullOrEmpty(Username))
            {
                Username = "Test";
            }
            else
            {
                Username = ApplicationSettings.CurrentUser.Username;
            }

        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        public void ShowDialog(string dialogName, DialogParameters parameters)
        {
            dialogService.ShowDialog(dialogName, parameters, r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.OK:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }/*, dialogWindowName*/);
        }

        private void ShowAddUserDialog()
        {
            DialogParameters parameters = new DialogParameters();
            ShowDialog("AddUserDialog", parameters);
        }

        private void ShowEditUserDialog()
        {
            DialogParameters parameters = new DialogParameters();
            ShowDialog("EditUserDialog", parameters);
        }

        private void Navigate(string path)
        {
            regionManager.RequestNavigate("MainMenuRegion", path);
        }
    }
}
