using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public MainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
    }
}
