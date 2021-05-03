using InspectionBoardLibrary.Database.Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace InspectionBoardLibrary.Domain.ViewModels.Dialogs
{
    public abstract class RemoveDialogViewModel<TEntity, TContext> : BindableBase, IDialogAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private IDialogParameters dialogParameters;
        private readonly IRepository<TEntity> repository;

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

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public virtual string Title => "Удаление сведений";

        public event Action<IDialogResult> RequestClose;

        public RemoveDialogViewModel(IRepository<TEntity> repository)
        {
            this.repository = repository;
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public async void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Ids = await repository.SelectIds();
            SelectedEntityId = Ids.FirstOrDefault();
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await repository.Remove(SelectedEntityId); ;
                result = ButtonResult.OK;
            }
            else if (parameter?.ToLower() == "false")
            {
                result = ButtonResult.Cancel;
            }

            RaiseRequestClose(new DialogResult(result));
        }
    }
}
