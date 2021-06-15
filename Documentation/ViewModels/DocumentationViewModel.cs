using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Documentation.ViewModels
{
    public class DocumentationViewModel : BindableBase, IDialogAware
    {
        private string TemplatesDefaultPath = $"{Directory.GetCurrentDirectory()}/Templates/";
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;

        public DocumentationViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            ShowDocDialogCommand = new DelegateCommand<string>(ShowDocDialog);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private string username;

        public event Action<IDialogResult> RequestClose;
        public DelegateCommand<string> ShowDocDialogCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }

        public string Username
        {
            get => username;
            set { SetProperty(ref username, value); }
        }

        public string Title => "Документация";

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public bool IsNavigationTarget(NavigationContext navigationContext) => true;

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }

        public void ShowDialog(string dialogName, DialogParameters parameters)
        {
            dialogService.ShowDialog(dialogName, parameters, r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.OK:
                        {
                            break;
                        }
                    default:
                        break;
                }
            }/*, dialogWindowName*/);
        }

        private void Navigate(string path)
        {
            regionManager.RequestNavigate("MainMenuRegion", path);
        }

        private void ShowDocDialog(string templateType)
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("templateType", templateType);
            parameters.Add("templatePath", TemplatesDefaultPath);
            ShowDialog("CreateDocumentDialog", parameters);
        }
    }
}
