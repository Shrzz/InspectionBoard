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

        private bool isMenuActive;
        public bool IsMenuActive
        {
            get { return isMenuActive; }
            set { SetProperty(ref isMenuActive, value); }
        }

        // свойство для перехода на новую страницу
        private MenuItem selectedMenuItem;
        public MenuItem SelectedMenuItem
        {
            get { return selectedMenuItem; }
            set { SetProperty(ref selectedMenuItem, value); }
        }

        // свойство для перехода на новую страницу
        private int selectedMenuIndex;
        public int SelectedMenuIndex
        {
            get { return selectedMenuIndex; }
            set { SetProperty(ref selectedMenuIndex, value); }
        }

        // поиск по пунктам меню
        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                if (SetProperty(ref searchKeyword, value))
                {
                    menuItemsView.Refresh();
                }
            }
        }

        // свойство для отображения названия на верхней панели
        private MenuItem currentMenuItem;
        public MenuItem CurrentMenuItem
        {
            get { return currentMenuItem; }
            set { SetProperty(ref currentMenuItem, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> ShowDialogCommand { get; private set; }
        public DelegateCommand GetApplicantsCommand { get; private set; }

        #endregion
        // лишняя прогрузка данных
        public MainViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            this.RegionName = "Главная страница";
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(Workspace.Views.Students));
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(Authorization.Views.Login));
            //regionManager.RegisterViewWithRegion("MainRegion", typeof(Main));
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(Students));



            MenuItems = new ObservableCollection<MenuItem>();
            foreach (var item in GenerateMenuItems())
            {
                MenuItems.Add(item);
            }

            SelectedMenuIndex = 0;
            menuItemsView = CollectionViewSource.GetDefaultView(MenuItems);
            menuItemsView.Filter = MenuItemsFilter;
            CurrentMenuItem = new MenuItem("Главная страница", "ContentRegion");
            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
            NavigateCommand = new DelegateCommand<string>(Navigate);

            DataSeeder seeder = new DataSeeder();
            seeder.AddAdminUser();
            seeder.AddGroups();
            seeder.AddStudent();
        }

        private static IEnumerable<MenuItem> GenerateMenuItems()
        {
            yield return new MenuItem("Студенты", "Students");
            yield return new MenuItem("Преподаватели", "Teachers");
            yield return new MenuItem("Предметы", "Subjects");
            yield return new MenuItem("Экзамены", "Exams");
            yield return new MenuItem("Группы", "Groups");
            yield return new MenuItem("Журналы", "Journals");
            yield return new MenuItem("Билеты", "Tickets");
        }

        #region methods

        private void Navigate(string region)
        {
            regionManager.RequestNavigate("MainRegion", region);
            CurrentMenuItem = SelectedMenuItem;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            regionManager.RegisterViewWithRegion("WorkspaceRegion", typeof(Students));
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private bool MenuItemsFilter(object obj)
        {
            if (string.IsNullOrWhiteSpace(searchKeyword))
            {
                return true;
            }

            return obj is MenuItem item
                   && item.Name.ToLower().Contains(searchKeyword.ToLower());
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
