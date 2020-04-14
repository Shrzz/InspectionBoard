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
    public class ViewCViewModel : BindableBase
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

        public DelegateCommand NavigateCommand { get; private set; }
        public DelegateCommand AddSpecialityCommand { get; private set; }

        public ViewCViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand(Navigate);
            AddSpecialityCommand = new DelegateCommand(AddSpeciality);
        }

        private void Navigate()
        {
            regionManager.RequestNavigate("ContentRegion", "Workspace");
        }

        private void AddSpeciality()
        {
            Message = "item added";
        }
    }
}
