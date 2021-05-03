using InspectionBoardLibrary.Database.Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.ViewModels.Dialogs
{
    public abstract class EditDialogViewModel<TEntity, TContext> : BindableBase, IDialogAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private IDialogParameters dialogParameters;
        private readonly IRepository<TEntity> repository;

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
            set { SetProperty(ref selectedEntityId, value); }
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

        public async Task EditEntity()
        {
            Entity.Id = SelectedEntityId;
            await repository.Update(Entity);
        }

        protected virtual async void CloseDialog(string parameter)
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

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public virtual async void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;
            Entities = await repository.Select();
            Ids = await repository.SelectIds();
            SelectedEntityId = 0;
            Entity = Entities[SelectedEntityId];
        }
    }
}
