using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.Searchers;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace InspectionBoardLibrary.Models.ViewModels.Pages
{
    public abstract class TablePage<TEntity, TContext> : BindableBase, INavigationAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly IDialogService dialogService;
        protected readonly IRepository<TEntity> repository;
        protected readonly ISearcher<TEntity> searcher;

        private ObservableCollection<TEntity> entities;
        public ObservableCollection<TEntity> Entities
        {
            get { return entities; }
            set { SetProperty(ref entities, value); }
        }

        private string searchKeyword;
        public string SearchKeyword
        {
            get { return searchKeyword; }
            set
            {
                SetProperty(ref searchKeyword, value);
                SelectedEntity = searcher.Search(Entities, SearchKeyword);
            }
        }

        public TEntity selectedEntity;
        public TEntity SelectedEntity
        {
            get => selectedEntity;
            set
            {
                SetProperty(ref selectedEntity, value);
            }
        }

        public TablePage(IDialogService dialogService, IRepository<TEntity> repository)
        {
            this.dialogService = dialogService;
            this.repository = repository;
            this.dialogService = dialogService;
            ShowDialogCommand = new DelegateCommand<string>(DefineDialogType);
        }

        public DelegateCommand<string> ShowDialogCommand { get; private set; }

        private void DefineDialogType(string dialogName)
        {
            if (dialogName.StartsWith("Add"))
            {
                ShowDialog(dialogName, "AddDialogWindow");
            }
            else if (dialogName.StartsWith("Edit"))
            {
                ShowDialog(dialogName, "EditDialogWindow");
            }
            else if (dialogName.StartsWith("Remove"))
            {
                ShowDialog(dialogName, "RemoveDialogWindow");
            }
        }

        private void ShowDialog(string dialogName, string dialogWindowName)
        {
            var parameters = new DialogParameters();
            dialogService.ShowDialog(dialogName, parameters, r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.None:
                        {
                            break;
                        }
                    case ButtonResult.OK:
                        {
                            Entities = repository.Select().Result;
                            break;
                        }
                    case ButtonResult.Cancel:
                        {
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

            }, dialogWindowName);
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var entities = await repository.Select();
            Entities = new ObservableCollection<TEntity>(entities);
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
