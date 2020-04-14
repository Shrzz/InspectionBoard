using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using Workspace.DBHandler;

namespace Workspace.ViewModels
{
    public class ViewBViewModel : BindableBase
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

        public ViewBViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            Specialities = DataBase.GetSpecialitiesList();
            SelectedItem = Specialities[0];
        }

        private void Navigate(string item)
        {
            var parameters = new NavigationParameters();
            parameters.Add("SelectedItem", SelectedItem);
            regionManager.RequestNavigate("ContentRegion", "Workspace", parameters);
        }
    }
}
