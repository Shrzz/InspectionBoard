using InspectionBoardLibrary.DataSeeder;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Views;

namespace InspectionBoard.ViewModels
{
    public class TestMainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;

        #region properties

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> ShowDialogCommand { get; private set; }
        public DelegateCommand GetApplicantsCommand { get; private set; }

        #endregion
        // лишняя прогрузка данных
        public TestMainWindowViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            regionManager.RegisterViewWithRegion("TestMainRegion", typeof(Authorization.Views.LoginWindow));

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
            regionManager.RequestNavigate("TestMainRegion", region);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

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
