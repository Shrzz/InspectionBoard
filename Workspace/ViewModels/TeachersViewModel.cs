using InspectionBoardLibrary.Database;
using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models;
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
    public class TeachersViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService dialogService;
        private readonly TeacherRepository repository;

        private ObservableCollection<Teacher> teachers;
        public ObservableCollection<Teacher> Teachers
        {
            get { return teachers; }
            set { SetProperty(ref teachers, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set 
            { 
                SetProperty(ref searchKeyword, value);
                SelectedTeacher = Teachers.FirstOrDefault(t => t.Id.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 t.Name.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 t.Surname.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 t.Patronymic.ToString().ToLower().Contains(SearchKeyword.ToLower())
                ) ?? Teachers.FirstOrDefault();
            }
        }

        private Teacher selectedTeacher;
        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                SetProperty(ref selectedTeacher, value);
            }
        }



        public TeachersViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            repository = new TeacherRepository(new ExamContext());
            ShowDialogCommand = new DelegateCommand<string>(ShowDialog);
        }

        public DelegateCommand<string> ShowDialogCommand { get; private set; }

        private void ShowDialog(string dialogName)
        {
            dialogService.ShowDialog(dialogName, r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.None:
                        {
                            break;
                        }
                    case ButtonResult.OK:
                        {
                            Teachers = repository.Select().Result;
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
            var collection = await repository.Select();
            Teachers = collection;
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
