using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.ViewModels
{
    public class SettingsViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public SettingsViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
    }
}
