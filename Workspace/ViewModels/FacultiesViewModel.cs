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
    public class FacultiesViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService dialogService;
        private readonly IDatabaseService<Faculty> service;

        private ObservableCollection<Faculty> faculties;
        public ObservableCollection<Faculty> Faculties
        {
            get { return faculties; }
            set { SetProperty(ref faculties, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                SetProperty(ref searchKeyword, value);
                SelectedFaculty = Faculties.FirstOrDefault(f => f.Name.ToLower().Contains(SearchKeyword.ToLower())) ?? Faculties.FirstOrDefault();
            }
        }

        private Faculty selectedFaculty;
        public Faculty SelectedFaculty
        {
            get { return selectedFaculty; }
            set
            {
                SetProperty(ref selectedFaculty, value);
            }
        }
        public FacultiesViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            service = new FacultyService();
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
                            Faculties = new ObservableCollection<Faculty>(service.Select());
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
            Faculties = new ObservableCollection<Faculty>(service.Select());
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
