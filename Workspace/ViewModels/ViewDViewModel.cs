using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.DBHandler;

namespace Workspace.ViewModels
{
    class ViewDViewModel : BindableBase
    {
        private IRegionManager regionManager;

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        private string item;
        public string Item
        {
            get { return item; }
            set { SetProperty(ref item, value); }
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


        public DelegateCommand NavigateCommand { get; private set; }
        public DelegateCommand DeleteSpecialityCommand { get; private set; }

        public ViewDViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand(Navigate);
            DeleteSpecialityCommand = new DelegateCommand(DeleteSpeciality);
            Specialities = DataBase.GetSpecialitiesList();
            SelectedItem = Specialities[0];
        }



        private void Navigate()
        {
            regionManager.RequestNavigate("ContentRegion", "Workspace");
        }

        private void DeleteSpeciality()
        {
            Message = "item deleted";
        }

    }
}
