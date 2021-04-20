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

namespace InspectionBoard.Dialogs.GroupsDialogs
{
    public class EditGroupDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly IDatabaseService<Group> service;

        private Group group;
        public Group Group
        {
            get { return group; }
            set { SetProperty(ref group, value); }
        }

        private int selectedFacultyId;
        public int SelectedFacultyId
        {
            get { return selectedFacultyId; }
            set { SetProperty(ref selectedFacultyId, value); }
        }

        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(service.SelectIds());
        }

        public string Title => "Изменить факультет";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditGroupDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new GroupService();
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditStudent()
        {
            Group.Id = SelectedFacultyId;
            await service.EditAsync(Group);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await EditStudent();
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
            Group = new Group();
        }
    }
}
