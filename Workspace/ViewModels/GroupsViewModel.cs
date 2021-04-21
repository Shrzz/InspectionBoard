using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
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
    public class GroupsViewModel : BindableBase, INavigationAware
    {
        private readonly IDialogService dialogService;
        private readonly GroupRepository repository;

        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get { return groups; }
            set { SetProperty(ref groups, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                SetProperty(ref searchKeyword, value);
                SelectedGroup = Groups.FirstOrDefault(f => f.Name.ToLower().Contains(SearchKeyword.ToLower())) ?? Groups.FirstOrDefault();
            }
        }

        private Group selectedGroup;
        public Group SelectedGroup
        {
            get { return selectedGroup; }
            set
            {
                SetProperty(ref selectedGroup, value);
            }
        }
        public GroupsViewModel(IDialogService dialogService)
        {
            this.dialogService = dialogService;
            repository = new GroupRepository(new ExamContext());
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
                            Groups = repository.Select().Result;
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
            Groups = await repository.Select();
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
