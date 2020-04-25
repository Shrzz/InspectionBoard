using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows;
using Workspace.DBHandler;

namespace Workspace.ViewModels
{
    public class ViewBViewModel : BindableBase, INavigationAware
    {
        private IRegionManager regionManager;

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private List<string> specialities;
        public List<string> Specialities
        {
            get { return specialities; }
            set { SetProperty(ref specialities, value); }
        }

        private string selectedItem;
        public string SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand ReturnCommand { get; private set; }

        public ViewBViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(ReturnSpeciality);
            ReturnCommand = new DelegateCommand(Return);
        }

        private void ReturnSpeciality(string item)
        {
            if (item == null)
            {
                MessageBox.Show("Необходимо выбрать специальность");
            }
            else
            {
                var parameters = new NavigationParameters
            {
                { "SelectedItem", SelectedItem }
            };
                regionManager.RequestNavigate("ContentRegion", "Workspace", parameters);
            }

        }

        private void Return()
        {
            regionManager.RequestNavigate("ContentRegion", "Workspace");
            return;
        }

        private string GetSelectedSpeciality()
        {
            if (Specialities.Count > 0)
            {
                return Specialities[0];
            }
            return "Специальностей нет";
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Specialities = DataBase.GetSpecialitiesList();
            SelectedItem = GetSelectedSpeciality();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
