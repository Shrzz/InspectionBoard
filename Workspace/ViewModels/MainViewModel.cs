using InspectionBoardLibrary.DatabaseHandler;
using InspectionBoardLibrary.Models;
using MaterialDesignColors;
using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;

namespace Workspace.ViewModels
{
    public class MainViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;

        #region properties

        private string speciality;
        public string Speciality
        {
            get { return speciality; }
            set { SetProperty(ref speciality, value); }
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

        private string searchString;
        public string SearchString
        {
            get { return searchString; }
            set 
            { 
                SetProperty(ref searchString, value);
                SelItem = Applicants.FirstOrDefault(c => c.Name.ToLower().Contains(SearchString.ToLower()) || c.Location.ToLower().Contains(SearchString.ToLower()) || c.ID.ToString().ToLower().Contains(SearchString.ToLower())) ?? applicants[0];
            }
        }

        private Applicant selItem;
        public Applicant SelItem
        {
            get { return selItem; }
            set { SetProperty(ref selItem, value); }
        }

        public DelegateCommand QuitCommand { get; set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        public DelegateCommand<string> ShowDialogCommand { get; private set; }
        public DelegateCommand AnalyzeCommand { get; private set; }
        public DelegateCommand GetApplicantsCommand { get; private set; }
        public DelegateCommand<string> DocsNavigateCommand { get; private set; }

        #endregion
        public MainViewModel(IRegionManager regionManager, IDialogService dialogService)
        {
            this.regionManager = regionManager;
            this.dialogService = dialogService;
            QuitCommand = new DelegateCommand(Quit);
            NavigateCommand = new DelegateCommand<string>(Navigate);
            ShowDialogCommand = new DelegateCommand<string>(ShowAddDialog);
            GetApplicantsCommand = new DelegateCommand(GetApplicants); 
            AnalyzeCommand = new DelegateCommand(Analyze);
            DocsNavigateCommand = new DelegateCommand<string>(DocsNavigate);
            Applicants = Dbc.GetApplicants();
            Speciality = "(не выбрано)";
        }

        #region methods
        private void Navigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                regionManager.RequestNavigate("ContentRegion", navigatePath);
            }
        }

        private void Analyze()
        {

            var p = new NavigationParameters
            {
                { "Applicants", Applicants }
            };
            regionManager.RequestNavigate("ContentRegion", "Analyze", p);      
        }

        private void DocsNavigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                NavigationParameters p = new NavigationParameters();
                p.Add("Applicants", new List<Applicant>(Applicants));
                regionManager.RequestNavigate("ContentRegion", navigatePath, p);
            };
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            if (navigationContext.Parameters["SelectedItem"] is string)
            {
                Speciality = navigationContext.Parameters["SelectedItem"].ToString();
                var temp = new List<Applicant>(Dbc.GetApplicants());
                Applicants = new ObservableCollection<Applicant>(
                    (from a in temp
                    where a.Speciality == Speciality
                    select a)
                    .ToList<Applicant>());
                return;
            }

            if (navigationContext.Parameters["ApplicantsAnalyzed"] is ObservableCollection<Applicant>)
            {
                Applicants = navigationContext.Parameters["ApplicantsAnalyzed"] as ObservableCollection<Applicant>;
            }
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public void ShowAddDialog(string dialogName)
        {
            dialogService.ShowDialog(dialogName, new DialogParameters($"message={SelectedSpeciality}"), r =>
            {
                if (r.Result == ButtonResult.None)
                {

                }

                else if (r.Result == ButtonResult.OK)
                {
                    Applicants = Dbc.GetApplicants();

                }

                else if (r.Result == ButtonResult.Cancel)
                {

                }
                else
                {

                }
            });
        } 

        private void GetApplicants()
        {
            Applicants = Dbc.GetApplicants();
            Speciality = "Нажмите для выбора специальности";
        }


        private void Quit()
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
}
