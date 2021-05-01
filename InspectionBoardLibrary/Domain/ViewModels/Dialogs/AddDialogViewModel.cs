﻿using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.DatabaseModels;
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
    public abstract class AddDialogViewModel<TEntity, TContext> : BindableBase, IDialogAware
        where TEntity : class, IEntity
        where TContext : DbContext
    {
        protected IDialogParameters dialogParameters;
        protected readonly EfRepository<TEntity, TContext> repository;

        private TEntity entity;
        public TEntity Entity
        {
            get { return entity; }
            set { SetProperty(ref entity, value); }
        }

        public string Title => "Добавление объекта";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddDialogViewModel(EfRepository<TEntity, TContext> repository)
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

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {

        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Entity = repository.SelectSingle(0).Result;
            //Date = DateTime.Today.Date;
        }
    }
}