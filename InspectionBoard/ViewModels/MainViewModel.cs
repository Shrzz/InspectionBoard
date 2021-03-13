using InspectionBoardLibrary.DatabaseHandler;
using InspectionBoardLibrary.DataSeeder;
using InspectionBoardLibrary.Models;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System.Data.Entity;
using System.Linq;
using System.Windows.Media;

namespace InspectionBoard.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private string title;
        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        private string applicants;
        public string Applicants
        {
            get { return applicants; }
            set { SetProperty(ref applicants, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(Authorization.Views.Login));
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }

    }
}
