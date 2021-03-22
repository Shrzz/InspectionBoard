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
    public class RetakesViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService dialogService;
        private readonly IDatabaseService<Retake> service;

        private ObservableCollection<Retake> retakes;
        public ObservableCollection<Retake> Retakes
        {
            get { return retakes; }
            set { SetProperty(ref retakes, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                SetProperty(ref searchKeyword, value);
                SelectedRetake = Retakes.FirstOrDefault(r => r.Id.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 r.Student.Surname.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 r.Teacher.Surname.ToString().ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 r.Subject.Name.ToLower().Contains(SearchKeyword.ToLower()) ||
                                                                 r.DateTime.ToString().ToLower().Contains(SearchKeyword.ToLower())
                ) ?? Retakes.FirstOrDefault();
            }
        }

        private Retake selectedRetake;
        public Retake SelectedRetake
        {
            get { return selectedRetake; }
            set
            {
                SetProperty(ref selectedRetake, value);
            }
        }
        public RetakesViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            service = new RetakeService();
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
                            Retakes = new ObservableCollection<Retake>(service.Select());
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
            Retakes = new ObservableCollection<Retake>(service.Select());
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
