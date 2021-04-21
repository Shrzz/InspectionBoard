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
        private readonly EfRepository<TEntity, TContext> repository;

        private int selectedEntityId;
        public int SelectedEntityId
        {
            get { return selectedEntityId; }
            set { SetProperty(ref selectedEntityId, value); }
        }

        public ObservableCollection<int> Ids
        {
            get => repository.SelectIds().Result;
        }

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public virtual string Title => "Удаление объекта";

        public event Action<IDialogParameters> RequestClose;

        public RemoveDialogViewModel(EfRepository<TEntity, TContext> repository)
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            this.repository = repository;
        }

        event Action<IDialogResult> IDialogAware.RequestClose
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }

        public bool CanCloseDialog() => true;

        public void OnDialogClosed()
        {

        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            SelectedEntityId = Ids.FirstOrDefault();
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke((IDialogParameters)dialogResult);
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
