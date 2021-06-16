using InspectionBoardLibrary.Models.Database;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Models
{
    public abstract class TablePage<TEntity, TContext> : BindableBase, INavigationAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected readonly IRegionManager regionManager;
        protected readonly IDialogService dialogService;
        protected readonly IRepository<TEntity> repository;
        protected ISearcher<TEntity> searcher;
        protected string RegionName;

        protected virtual string AddDialogName { get; set; }
        protected virtual string EditDialogName { get; set; }
        protected virtual string RemoveDialogName { get; set; }


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

        public TablePage(IDialogService dialogService, IRegionManager regionManager, IRepository<TEntity> repository)
        {
            this.dialogService = dialogService;
            this.repository = repository;
            this.regionManager = regionManager;
            ShowAddDialogCommand = new DelegateCommand(ShowAddDialog);
            ShowEditDialogCommand = new DelegateCommand(ShowEditDialog);
            ShowRemoveDialogCommand = new DelegateCommand(ShowRemoveDialog);
            ShowDescriptionCommand = new DelegateCommand(ShowDescriptionDialog);
            RemoveEntityCommand = new DelegateCommand(RemoveEntity);
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        public DelegateCommand ShowAddDialogCommand { get; private set; }
        public DelegateCommand ShowEditDialogCommand { get; private set; }
        public DelegateCommand ShowRemoveDialogCommand { get; private set; }
        public DelegateCommand ShowDescriptionCommand { get; private set; }
        public DelegateCommand RemoveEntityCommand { get; private set; }
        public DelegateCommand<string> NavigateCommand { get; private set; }
        
        public void ShowDialog(string dialogName, string dialogWindowName, DialogParameters parameters)
        {
            dialogService.ShowDialog(dialogName, parameters, async r =>
            {
                switch (r.Result)
                {
                    case ButtonResult.OK:
                        {
                            Entities = await repository.SelectAsync();
                            break;
                        }
                    default:
                        break;
                }
            }, dialogWindowName);
        }

        public virtual void ShowAddDialog()
        {
            DialogParameters parameters = new DialogParameters();
            ShowDialog(AddDialogName, "AddDialogWindow", parameters);
        }

        public virtual void ShowEditDialog()
        {
            DialogParameters parameters = new DialogParameters();
            if (SelectedEntity != null)
            {
                parameters.Add("id", SelectedEntity.Id);
            }
            ShowDialog(EditDialogName, "EditDialogWindow", parameters);
        }

        public virtual void ShowEditDialog(int id)
        {
            DialogParameters parameters = new DialogParameters();
            parameters.Add("Id", id);
            ShowDialog(EditDialogName, "EditDialogWindow", parameters);
        }

        public virtual void ShowRemoveDialog()
        {
            DialogParameters parameters = new DialogParameters();
            ShowDialog(RemoveDialogName, "RemoveDialogWindow", parameters);
        }

        public async virtual void RemoveEntity()
        {
            await repository.Remove(SelectedEntity.Id);
            Entities = await repository.SelectAsync();
        }

        public void ShowDescriptionDialog()
        {
            var parameters = new DialogParameters();
            parameters.Add("Entity", SelectedEntity);

            dialogService.ShowDialog("DescriptionDialog", parameters, r => { }, "DescriptionDialogWindow");
        }

        public virtual async void OnNavigatedTo(NavigationContext navigationContext)
        {
            var entities = await repository.SelectAsync();
            Entities = new ObservableCollection<TEntity>(entities);
            Entities.CollectionChanged += Entities_CollectionChanged;
        }

        private async void Entities_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Replace)
            {
                Entities = await repository.SelectAsync();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }

        private void Navigate(string region)
        {
            regionManager.RequestNavigate("MainRegion", region);
        }
    }
}
