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
    public class TablesViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public TablesViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string region)
        {
            regionManager.RequestNavigate("MainRegion", region);
        }
    }
}
