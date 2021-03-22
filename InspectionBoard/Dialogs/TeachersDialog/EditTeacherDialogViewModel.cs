﻿using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Database.Extensions;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.TeachersDialog
{
    public class EditTeacherDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private IDatabaseService<Teacher> service;

        private Teacher teacher;
        public Teacher Teacher
        {
            get { return teacher; }
            set { SetProperty(ref teacher, value); }
        }

        private int selectedTeacherId;
        public int SelectedTeacherId
        {
            get { return selectedTeacherId; }
            set { SetProperty(ref selectedTeacherId, value); }
        }

        public ObservableCollection<int> Ids
        {
            get => new ObservableCollection<int>(service.SelectIds());
        }

        public ObservableCollection<Category> Categories
        {
            get => new ObservableCollection<Category>((service as TeacherService).SelectEducationForms());
        }

        public string Title => "Изменить сведения о преподавателе";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditTeacherDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            service = new TeacherService();
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditSubject()
        {
            Teacher.Id = SelectedTeacherId;
            service = new TeacherService();
            await service.EditAsync(Teacher);
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
            Teacher = new Teacher();
            SelectedTeacherId = Ids.FirstOrDefault();
        }
    }
}
