using InspectionBoardLibrary.Models.Database;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Dialogs
{
    public abstract class EditDialogViewModel<TEntity, TContext> : BindableBase, IDialogAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected IDialogParameters dialogParameters;
        protected readonly IRepository<TEntity> repository;

        private string message;
        public string Message
        {
            get => message;
            set { SetProperty(ref message, value); }
        }

        private TEntity entity;
        public TEntity Entity
        {
            get { return entity; }
            set { SetProperty(ref entity, value); }
        }

        private ObservableCollection<TEntity> entities;
        public ObservableCollection<TEntity> Entities
        {
            get => entities;
            set { SetProperty(ref entities, value); }
        }

        private int selectedEntityId;
        public int SelectedEntityId
        {
            get { return selectedEntityId; }
            set 
            {
                SetProperty(ref selectedEntityId, value);
                SetFirstEntity();
            }
        }

        private ObservableCollection<int> ids;
        public ObservableCollection<int> Ids
        {
            get => ids;
            set { SetProperty(ref ids, value); }
        }

        public string Title => "Изменение сведений";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditDialogViewModel(IRepository<TEntity> repository)
        {
            this.repository = repository;
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public event Action<IDialogResult> RequestClose;

        public virtual async Task EditEntity()
        {
            if (Entity != null)
            {
                await repository.Update(Entity);
            }
        }

        public virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await EditEntity();
                result = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
            {
                result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }

        private async void SetFirstEntity()
        {
            Entity = await repository.SelectSingle(SelectedEntityId);
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public async virtual void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            var list = await repository.SelectAsync();
            if (list.Count > 0) 
            {
                Entities = list;
                Entity = Entities.FirstOrDefault();
                Ids = await repository.SelectIds();
                var id = parameters.GetValue<int>("id");
                if (id > 0)
                {
                    SelectedEntityId = id;
                }
                else
                {
                    SelectedEntityId = Ids.First();
                }
            }
        }
    }
}
