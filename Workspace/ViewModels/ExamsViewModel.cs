using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
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

namespace Workspace.ViewModels
{
    public class ExamsViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService dialogService;
        private readonly IDatabaseService<Exam> service;

        private ObservableCollection<Exam> exams;
        public ObservableCollection<Exam> Exams
        {
            get { return exams; }
            set { SetProperty(ref exams, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set 
            { 
                SetProperty(ref searchKeyword, value);
                SelectedExam = Exams.FirstOrDefault(e => e.Id.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 e.Student.Surname.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 e.Teacher.Surname.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 e.Subject.Name.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 e.Date.ToString().ToLower().Contains(SearchKeyword.ToLower())
                ) ?? Exams.FirstOrDefault();
            }
        }

        private Exam selectedExam;
        public Exam SelectedExam 
        {
            get { return selectedExam; }
            set
            {
                SetProperty(ref selectedExam, value);
            }
        }
        public ExamsViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            service = new ExamService();
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
                            Exams = new ObservableCollection<Exam>(service.Select());
                            break;
                        }
                    case ButtonResult.Cancel:
                        {
                            break;
                        }
                }
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            Exams = new ObservableCollection<Exam>(service.Select());
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
