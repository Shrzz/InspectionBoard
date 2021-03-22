using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.RetakesDialogs
{
    public class RemoveRetakeDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly IDatabaseService<Retake> service;

        private int selectedRetakeId;
        public int SelectedRetakeId
        {
            get { return selectedRetakeId; }
            set { SetProperty(ref selectedRetakeId, value); }
        }
        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(service.SelectIds());
        }
        public string Title => "Удалить сведения о пересдаче";

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public RemoveRetakeDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new RetakeService();
        }

        public event Action<IDialogResult> RequestClose;
        private async Task RemoveRetake()
        {
            await service.RemoveAsync(SelectedRetakeId);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await RemoveRetake();
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
            this.dialogParameters = parameters;
            SelectedRetakeId = Ids.FirstOrDefault();
        }
    }
}
