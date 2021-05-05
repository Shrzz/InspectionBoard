using InspectionBoardLibrary.Models.Database;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Dialogs
{
    public abstract class AddDialogViewModel<TEntity, TContext> : BindableBase, IDialogAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected IDialogParameters dialogParameters;
        protected readonly IRepository<TEntity> repository;

        private TEntity entity;
        public TEntity Entity
        {
            get { return entity; }
            set { SetProperty(ref entity, value); }
        }

        public string Title => "Добавление сведений";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddDialogViewModel(IRepository<TEntity> repository)
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            this.repository = repository;
        }

        public event Action<IDialogResult> RequestClose;

        private async Task AddEntity()
        {
            await repository.Add(Entity);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await AddEntity();
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

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
        }
    }
}
