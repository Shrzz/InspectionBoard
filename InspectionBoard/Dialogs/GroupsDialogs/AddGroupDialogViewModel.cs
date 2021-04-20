using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.GroupsDialogs
{
    public class AddGroupDialogViewModel : BindableBase, IDialogAware
    {
        private IDatabaseService<Group> service;
        public string Title => "Добавить факультет";

        private Group group;
        public Group Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }

        public event Action<IDialogResult> RequestClose;

        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddGroupDialogViewModel()
        {
            service = new GroupService();
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }
        private async Task AddFaculty()
        {
            await service.AddAsync(Group);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await AddFaculty();
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
            Group = new Group();
        }
    }
}
