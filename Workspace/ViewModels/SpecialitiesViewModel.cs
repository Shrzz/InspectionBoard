using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Windows;
using System.Linq;
using System.Windows.Navigation;
using InspectionBoardLibrary.DatabaseHandler;

namespace Workspace.ViewModels
{
    public class SpecialitiesViewModel : BindableBase, INavigationAware
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

        public SpecialitiesViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(ReturnSpecialities);
            ReturnCommand = new DelegateCommand(Return);
            Specialities = Dbc.GetFacultiesList();
            
        }

        private void ReturnSpecialities(string item)
        {
            if (SelectedItem == null)
            {
                MessageBox.Show("Необходимо выбрать специальность");
            }
            else
            {
                var p = new NavigationParameters
                {
                    { "SelectedItem", SelectedItem }
                };
                regionManager.RequestNavigate("ContentRegion", "Workspace", p);
            }
        }

        private void Return()
        {
            regionManager.RequestNavigate("ContentRegion", "Workspace");
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
            Specialities = Dbc.GetFacultiesList();
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
