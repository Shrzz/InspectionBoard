using InspectionBoardLibrary.Database.Domain;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Domain.ViewModels.Dialogs
{
    public abstract class EditDialogViewModel<TEntity, TContext> : BindableBase, IDialogAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        private IDialogParameters dialogParameters;
        private readonly EfRepository<TEntity, TContext> repository;

        private TEntity entity;
        public TEntity Entity
        {
            get { return entity; }
            set { SetProperty(ref entity, value); }
        }

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

        public string Title => "Изменение сведений";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditDialogViewModel(EfRepository<TEntity, TContext> repository)
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            this.repository = repository;
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditSubject()
        {
            Entity.Id = SelectedEntityId;
            await repository.Update(Entity);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await EditSubject();
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

        public void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Entity = repository.SelectSingle(0).Result;
            SelectedEntityId = Ids.FirstOrDefault();
        }
    }
}
