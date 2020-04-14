using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using Prism.Mvvm;
using Prism.Commands;
using Prism.Services.Dialogs;
using Prism.Ioc;
using InspectionBoard.Dialogs;
using InspectionBoard.Views;
using Prism.Regions;
using Unity;
using System.ComponentModel;

namespace InspectionBoard.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public IDialogService DialogService { get; set; }

        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
        }

        public DelegateCommand<string> NavigateCommand { get; private set; }

        public MainViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.DialogService = dialogService;
            NavigateCommand = new DelegateCommand<string>(Navigate);
            //regionManager.RegisterViewWithRegion("ContentRegion", typeof(Workspace.Views.ViewA));//
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(Authorization.Views.ViewA));
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
