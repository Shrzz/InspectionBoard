using InspectionBoardLibrary.Models;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.ViewModels
{
    public class SettingsViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        public SettingsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;

        }

        private string username;
        public string Username
        {
            get => username;
            set { SetProperty(ref username, value); }
        }

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
    }
}
