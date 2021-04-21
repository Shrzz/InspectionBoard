using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Linq;

namespace Workspace.ViewModels
{
    public class StudentsViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService dialogService;
        private readonly StudentRepository repository;

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { SetProperty(ref students, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set 
            {
                SetProperty(ref searchKeyword, value);
                SelectedStudent = Students.FirstOrDefault(s => s.Id.ToString().ToLower().Contains(SearchKeyword.ToLower())||
                                                                 s.Name.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 s.Surname.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 s.Patronymic.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 s.Group.Name.ToLower().Contains(SearchKeyword.ToLower()) 
                ) ?? Students.FirstOrDefault();     
            }
        }

        public Student selectedStudent;
        public Student SelectedStudent
        {
            get => selectedStudent;
            set
            {
                SetProperty(ref selectedStudent, value);
            }
        }

        public StudentsViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            repository = new StudentRepository(new ExamContext());
            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
        }

        public DelegateCommand<string> ShowDialogCommand { get; private set; }

        private void ShowDialog(string dialogName)
        {
            dialogService.ShowDialog(dialogName, new DialogParameters(), r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.None:
                        {
                            break;
                        }
                    case ButtonResult.OK:
                        {
                            Students = repository.Select().Result;
                            break;
                        }
                    case ButtonResult.Cancel:
                        {
                            break;
                        }
                }
            });
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var students = await repository.Select();
            Students = new ObservableCollection<Student>(students);
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }
    }
}
