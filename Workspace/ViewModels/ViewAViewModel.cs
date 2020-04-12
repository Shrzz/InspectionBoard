using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Models;

namespace Workspace.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private ObservableCollection<Applicant> applicants;
        public ObservableCollection<Applicant> Applicants
        {
            get { return applicants; }
            set { SetProperty(ref applicants, value); }
        }

        private string selectedSpeciality;
        public string SelectedSpeciality
        {
            get { return selectedSpeciality; }
            set { SetProperty(ref selectedSpeciality, value); }
        }

        public DelegateCommand QuitCommand { get; set; }

        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand ChangeCommand { get; private set; }
        

        public IDialogService _dialogService { get; set; }

        public ViewAViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this._dialogService = dialogService;
            QuitCommand = new DelegateCommand(Quit);
            ChangeCommand = new DelegateCommand(ChangeMessage);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }

        private void ChangeMessage()
        {
            Message = "новое соообщение";
        }

        private void ShowDialog()
        {
            var message = "This is a message that should be shown in the dialog.";
            _dialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>
            {
                if (r.Result == ButtonResult.None)

                    SelectedSpeciality = "Result is None";
                else if (r.Result == ButtonResult.OK)
                    SelectedSpeciality = "Result is OK";
                else if (r.Result == ButtonResult.Cancel)
                    Message = "Result is Cancel";
                else
                    Message = "I Don't know what you did!?";
            });
        }

        private void Quit()
        {
            ShowDialog();
            // Application.Current.Shutdown();
        }
    }
}
