using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workspace.ViewModels
{
    public class ViewEViewModel : BindableBase
    {
        private IRegionManager regionManager;

        private string amount;
        public string Amount
        {
            get { return amount; }
            set { SetProperty(ref amount, value); }
        }

        public DelegateCommand NavigateCommand { get; private set; }
        public ViewEViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand(Navigate);
        }

        private void Navigate()
        {
            regionManager.RequestNavigate("ContentRegion", "Workspace");
        }
    }
}
