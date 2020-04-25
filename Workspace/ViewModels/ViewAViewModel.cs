using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using Workspace.DBHandler;
using Workspace.Models;

namespace Workspace.ViewModels
{
    public class ViewAViewModel : BindableBase, INavigationAware
    {
        #region properties
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;

        private string speciality;
        public string Speciality
        {
            get { return speciality; }
            set { SetProperty(ref speciality, value); }
        }

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

        private Applicant a;
        public Applicant A
        {
            get { return a; }
            set { SetProperty(ref a, value); }
        }

        public DelegateCommand QuitCommand { get; set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand ChangeCommand { get; private set; }
        public DelegateCommand<string> ShowDialogCommand { get; private set; }

        #endregion

        public ViewAViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            QuitCommand = new DelegateCommand(Quit);
            ChangeCommand = new DelegateCommand(ChangeMessage);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            ShowDialogCommand = new DelegateCommand<string>(ShowAddDialog);
            Applicants = new ObservableCollection<Applicant>();
            Applicants.CollectionChanged += CollectionChanged;
        }

        #region methods
        private void Navigate(string navigatePath)   
        {
            if (navigatePath != null)
            {
                regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }

        public void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    try
                    {
                        DataBase.AddApplicant(SelectedSpeciality, e.NewItems[0] as Applicant);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось добавить абитуриента в базу данных");

                    }
                    break;
                case NotifyCollectionChangedAction.Remove:
                    try
                    {
                        DataBase.DeleteApplicant(SelectedSpeciality, e.OldItems[0] as Applicant);
                    }
                    catch
                    {
                        MessageBox.Show("Не удалось удалить абитуриента из базы данных");
                    }
                    break;
            }
        }   //возможно снести нахер

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            Speciality = navigationContext.Parameters["SelectedItem"] as string;
            if (!String.IsNullOrEmpty(Speciality))
            {
                Applicants = DataBase.GetApplicants(Speciality);
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

        private void ChangeMessage()//удалить потом
        {
            Message = "новое соообщение";
        }

        public void ShowAddDialog(string dialogName)
        {
            dialogService.ShowDialog(dialogName, new DialogParameters($"message={SelectedSpeciality}"), r =>
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
        } //диалоги

        private void Quit()
        {
            Application.Current.Shutdown();
        }


        #endregion
    }
}
