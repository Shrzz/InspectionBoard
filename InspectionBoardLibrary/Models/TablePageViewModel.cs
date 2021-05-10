using InspectionBoardLibrary.Models.Database;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace InspectionBoardLibrary.Models
{
    public abstract class TablePage<TEntity, TContext> : BindableBase, INavigationAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly IDialogService dialogService;
        protected readonly IRepository<TEntity> repository;
        protected ISearcher<TEntity> searcher;

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
                if (searchKeyword.Length > 0 && Entities.Count > 0)
                {
                    SelectedEntity = repository.Searcher.Search(Entities, SearchKeyword);
                }
                else
                {
                    SelectedEntity = null;
                }
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

        private async void ShowDialog(string dialogName, string dialogWindowName)
        {
            var parameters = new DialogParameters();
            dialogService.ShowDialog(dialogName, parameters, async r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.None:
                        {
                            break;
                        }
                    case ButtonResult.OK:
                        {
                            Entities = await repository.Select();
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

        public virtual async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var entities = await repository.Select();
            Entities = new ObservableCollection<TEntity>(entities);
            Entities.CollectionChanged += Entities_CollectionChanged;
        }

        private async void Entities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {

            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                Entities = await repository.Select();
            }
            
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
