﻿using InspectionBoardLibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;

namespace InspectionBoardLibrary.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;
        private readonly ICollectionView menuItemsView;

        public ObservableCollection<MenuItem> MenuItems { get; }
        public ObservableCollection<MenuItem> AdditionalMenuItems { get; }

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

        private int selectedAdditionalMenuIndex;
        public int SelectedAdditionalMenuIndex
        {
            get { return selectedMenuIndex; }
            set { SetProperty(ref selectedMenuIndex, value); }
        }

        private MenuItem selectedAdditionalMenuItem;
        public MenuItem SelectedAdditionalMenuItem
        {
            get { return selectedMenuItem; }
            set { SetProperty(ref selectedMenuItem, value); }
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

        public DelegateCommand NavigateCommand { get; private set; }
        public DelegateCommand<string> ShowDialogCommand { get; private set; }
        public DelegateCommand GetApplicantsCommand { get; private set; }

        #endregion
        // лишняя прогрузка данных
        public MainViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;

            //regionManager.RegisterViewWithRegion("MainRegion", typeof(Authorization.Views.Login));

            MenuItems = new ObservableCollection<MenuItem>();
            foreach (var item in GenerateMenuItems())
            {
                MenuItems.Add(item);
            }

            AdditionalMenuItems = new ObservableCollection<MenuItem>();
            foreach (var item in GenerateAdditionalMenuItems())
            {
                AdditionalMenuItems.Add(item);
            }

            SelectedMenuIndex = 0;
            SelectedAdditionalMenuIndex = 0;
            menuItemsView = CollectionViewSource.GetDefaultView(MenuItems);
            menuItemsView.Filter = MenuItemsFilter;
            CurrentMenuItem = new MenuItem("Главная страница", "ContentRegion");

            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
            NavigateCommand = new DelegateCommand(Navigate);

            DataSeeder.DataSeeder seeder = new DataSeeder.DataSeeder();
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
            yield return new MenuItem("Тестовая", "Workspace");

        }

        private static IEnumerable<MenuItem> GenerateAdditionalMenuItems()
        {
            yield return new MenuItem("Документы", "Documents");
            yield return new MenuItem("Билеты", "Tickets");
            yield return new MenuItem("Настройки", "Settings");     
        }

        #region methods

        private void Navigate()
        {
            if (SelectedMenuItem != null)
            {
                regionManager.RequestNavigate(CurrentMenuItem.Region, "ContentRegion");
                regionManager.RequestNavigate("ContentRegion", SelectedMenuItem.Region);
                CurrentMenuItem = SelectedMenuItem;
                SelectedMenuItem = null;
            }
            else if (SelectedAdditionalMenuItem != null)
            {
                regionManager.RequestNavigate(CurrentMenuItem.Region, "ContentRegion");
                regionManager.RequestNavigate("ContentRegion", SelectedAdditionalMenuItem.Region);
                CurrentMenuItem = SelectedAdditionalMenuItem;
                SelectedAdditionalMenuItem = null;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

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
