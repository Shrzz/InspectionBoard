using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.DataSeeder;
using InspectionBoardLibrary.Models;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using Workspace.Domain;

namespace InspectionBoard.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;
        private readonly ICollectionView menuItemsView;

        public ObservableCollection<MenuItem> MenuItems { get; }

        #region properties

        private bool isMenuActive;
        public bool IsMenuActive
        {
            get { return isMenuActive; }
            set { SetProperty(ref isMenuActive, value); }
        }

        private MenuItem selectedItem;
        public MenuItem SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        private int selectedIndex;
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { SetProperty(ref selectedIndex, value); }
        }

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

        private string currentView;
        public string CurrentView
        {
            get { return currentView; }
            set { SetProperty(ref currentView, value); }
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
            regionManager.RegisterViewWithRegion("MainRegion", typeof(Authorization.Views.Login));

            MenuItems = new ObservableCollection<MenuItem>();
            foreach (var item in GenerateMenuItems())
            {
                MenuItems.Add(item);
            }
            SelectedIndex = 0;
            menuItemsView = CollectionViewSource.GetDefaultView(MenuItems);
            menuItemsView.Filter = MenuItemsFilter;

            NavigateCommand = new DelegateCommand<string>(Navigate);
            ShowDialogCommand = new DelegateCommand<string>(ShowAddDialog);

            CurrentView = "ContentRegion";
        }

        private static IEnumerable<MenuItem> GenerateMenuItems()
        {
            yield return new MenuItem("Студенты", "Students");
            yield return new MenuItem("Преподаватели", "Teachers");
            yield return new MenuItem("Предметы", "Subjects");
            yield return new MenuItem("Экзамены", "Exams");
            yield return new MenuItem("Пересдачи", "Retakes");
        }

        #region methods

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                regionManager.RequestNavigate(CurrentView, "ContentRegion");
                regionManager.RequestNavigate("ContentRegion", navigatePath);
                CurrentView = navigatePath;
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public void ShowAddDialog(string dialogName)
        {
            //в параметрах передаётся название специальности
            dialogService.ShowDialog(dialogName, new DialogParameters($"message=poit"), r =>
            {
                if (r.Result == ButtonResult.None)
                {

                }
                else if (r.Result == ButtonResult.OK)
                {

                }
                else if (r.Result == ButtonResult.Cancel)
                {

                }
                else
                {

                }
            });
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
        #endregion


    }
}
