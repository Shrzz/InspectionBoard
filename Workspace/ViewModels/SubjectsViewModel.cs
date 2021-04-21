using InspectionBoardLibrary.Database;
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
    public class SubjectsViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService dialogService;
        private readonly SubjectRepository repository;

        private ObservableCollection<Subject> subjects;
        public ObservableCollection<Subject> Subjects
        {
            get { return subjects; }
            set { SetProperty(ref subjects, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                SetProperty(ref searchKeyword, value);
                SelectedSubject = Subjects.FirstOrDefault(s => s.Id.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 s.Name.ToString().ToLower().Contains(SearchKeyword.ToLower())
                ) ?? Subjects.FirstOrDefault();
            }
        }

        private Subject selectedSubject;
        public Subject SelectedSubject
        {
            get { return selectedSubject; }
            set
            {
                SetProperty(ref selectedSubject, value);
            }
        }

        public SubjectsViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            repository = new SubjectRepository(new ExamContext());
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
                            Subjects = repository.Select().Result;
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
            Subjects = await repository.Select();
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
