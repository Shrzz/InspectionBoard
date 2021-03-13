using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.DataSeeder;
using InspectionBoardLibrary.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
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

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
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
                SelectedItem = Students.FirstOrDefault(c => c.Name.ToLower().Contains(SearchString.ToLower()) ||
                                                            c.Id.ToString().ToLower().Contains(SearchString.ToLower()) ||
                                                            c.Patronymic.ToLower().Contains(SearchString.ToLower()) ||
                                                            c.Surname.ToLower().Contains(SearchString.ToLower())
                                                        ) ?? students[0];
            }
        }

        private Student selectedItem;
        public Student SelectedItem
        {
            get { return selectedItem; }
            set { SetProperty(ref selectedItem, value); }
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
            Students = new ObservableCollection<Student>(Dbc.GetStudentList());
            Speciality = "(не выбрано)";

            using (ExamContext context = new ExamContext())
            {
                if (!context.Students.Any())
                {
                    DataSeeder seeder = new DataSeeder();
                    seeder.AddStudent();
                }
            }
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
                { "Students", Students }
            };

            regionManager.RequestNavigate("ContentRegion", "Analyze", p);
        }

        private void DocsNavigate(string navigatePath)
        {
            if (navigatePath != null)
            {
                NavigationParameters p = new NavigationParameters();
                p.Add("Students", new List<Student>(Students));
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
                var temp = Dbc.GetStudentList();
                Students = new ObservableCollection<Student>(
                    (from a in temp
                     where a.Faculty.Name == Speciality
                     select a)
                    .ToList());
                return;
            }

            if (navigationContext.Parameters["ApplicantsAnalyzed"] is ObservableCollection<Student>)
            {
                Students = navigationContext.Parameters["ApplicantsAnalyzed"] as ObservableCollection<Student>;
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
                    Students = new ObservableCollection<Student>(Dbc.GetStudentList());

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
            Students = new ObservableCollection<Student>(Dbc.GetStudentList());
            Speciality = "Нажмите для выбора специальности";
        }


        private void Quit()
        {
            Application.Current.Shutdown();
        }
        #endregion
    }
}
