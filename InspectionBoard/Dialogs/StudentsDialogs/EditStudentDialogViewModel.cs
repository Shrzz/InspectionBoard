﻿using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.StudentsDialogs
{
    public class EditStudentDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;
        private readonly StudentRepository repository;

        private Student student;
        public Student Student
        {
            get { return student; }
            set { SetProperty(ref student, value); }
        }

        private int selectedStudentId;
        public int SelectedStudentId
        {
            get { return selectedStudentId; }
            set { SetProperty(ref selectedStudentId, value); }
        }

        public ObservableCollection<int> Ids
        {
            get => repository.SelectIds().Result;
        }

        public ObservableCollection<Group> Groups
        {
            get => repository.SelectGroups().Result;
        }

        public List<string> EducationForms
        {
            get => new List<string>(Enum.GetNames(typeof(EducationForm)));
        }

        public string Title => "Изменить данные студента";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditStudentDialogViewModel()
        {
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
            repository = new StudentRepository(new ExamContext());
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditStudent()
        {
            Student.Id = SelectedStudentId;
            await repository.Update(Student);
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
            Student = new Student();
            SelectedStudentId = Ids.FirstOrDefault();
            Student.Group = Groups.FirstOrDefault();
        }
    }
}
