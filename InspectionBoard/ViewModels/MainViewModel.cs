using InspectionBoardLibrary.DataSeeder;
using InspectionBoardLibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using Workspace.Views;

namespace InspectionBoard.ViewModels
{
    public class MainViewModel : BindableBase
    { 
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;
        private readonly ICollectionView menuItemsView;

        public string RegionName { get; }
        public ObservableCollection<MenuItem> MenuItems { get; }

        #region properties

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> ShowDialogCommand { get; private set; }
        public DelegateCommand GetApplicantsCommand { get; private set; }

        #endregion
        // лишняя прогрузка данных
        public MainViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;

            MenuItems = new ObservableCollection<MenuItem>();

            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
            NavigateCommand = new DelegateCommand<string>(Navigate);

            DataSeeder seeder = new DataSeeder();
            seeder.AddAdminUser();
            seeder.AddGroups();
            seeder.AddStudent();
        }

        #region methods

        private void Navigate(string region)
        {
            regionManager.RequestNavigate("MainRegion", region);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            regionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(Students));
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
        private void ShowDialog(string dialogName)
        {
            dialogService.ShowDialog(dialogName, new DialogParameters(), r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.None:
                        {
                            break;
                        }
                    case ButtonResult.OK:
                        {
                            break;
                        }
                    case ButtonResult.Cancel:
                        {
                            break;
                        }
                }
            });
        }
        #endregion


    }
}
