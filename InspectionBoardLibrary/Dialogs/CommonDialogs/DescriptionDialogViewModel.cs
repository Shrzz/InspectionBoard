using InspectionBoardLibrary.Models.Database;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace InspectionBoardLibrary.Dialogs.CommonDialogs
{
    public class DescriptionDialogViewModel : BindableBase, IDialogAware
    {
        private IEntity entity;
        public IEntity Entity
        {
            get => entity;
            set { SetProperty(ref entity, value); }
        }

        private string description;
        public string Description
        {
            get => description;
            set { SetProperty(ref description, value); }
        }

        public string Title => "Просмотр сведений";

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public DescriptionDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public event Action<IDialogResult> RequestClose;

        public virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
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

        public void OnDialogOpened(IDialogParameters parameters)
        {
            Entity = parameters.GetValue<IEntity>("Entity");
            Description = Entity.GetFullDescription();
        }
    }
}
