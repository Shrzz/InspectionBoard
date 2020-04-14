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
using System.Windows;
using Workspace.DBHandler;
using Workspace.Models;

namespace Workspace.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        private string speciality;
        public string Speciality
        {
            get { return speciality; }
            set { SetProperty(ref speciality, value); }
        }
        private readonly IRegionManager regionManager;

        #region properties
        private string message;
        public string Message
        {
            get { return message; }
            set { SetProperty(ref message, value); }
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

        public IDialogService DialogService { get; set; }
        public DelegateCommand QuitCommand { get; set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand ChangeCommand { get; private set; }
        public DelegateCommand ShowDialogCommand { get; private set; }

        #endregion

        public ViewAViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            Applicant a = new Applicant
            {
                BirthDate = DateTime.Now.ToString(),
                ID = 0,
                Location = "location0",
                Mark = "mark0",
                Name = "name0",
                Speciality = "spec0"
            };
            applicants = new ObservableCollection<Applicant>()
            {
                a
            };
            this.regionManager = regionManager;
            this.DialogService = dialogService;       
            QuitCommand = new DelegateCommand(Quit);
            ChangeCommand = new DelegateCommand(ChangeMessage);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            ShowDialogCommand = new DelegateCommand(ShowDialog);
            

        }       //потом удалить челиков

        #region methods
        private void Navigate(string navigatePath)      //можно юзануть при логауте
        {
            if (navigatePath != null)
            {
                regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Speciality = navigationContext.Parameters["SelectedItem"] as string;
            if (!String.IsNullOrEmpty(Speciality))
            {
                //Applicants = DataBase.GetApplicants(Speciality);
            }
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            var spec = navigationContext.Parameters["SelectedItem"] as string;
            if (spec != null)
            {
                Speciality = spec;
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void ChangeMessage()
        {
            Message = "новое соообщение";
        }
        private void ShowDialog()
        {
            var message = "This is a message that should be shown in the dialog.";
            DialogService.ShowDialog("NotificationDialog", new DialogParameters($"message={message}"), r =>
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
            Application.Current.Shutdown();
        }


        #endregion
    }
}
