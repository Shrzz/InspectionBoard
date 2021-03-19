﻿using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.StudentsDialogs
{
    public class AddStudentDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;

        private Student student;
        public Student Student
        {
            get { return student; }
            set { SetProperty(ref student, value); }
        }
        public ObservableCollection<Faculty> Faculties
        {
            get => new ObservableCollection<Faculty>(FacultyService.Select());
        }

        public ObservableCollection<EducationForm> EducationForms
        {
            get => new ObservableCollection<EducationForm>(EducationFormService.Select());
        }

        public string Title => "Добавить студента";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public AddStudentDialogViewModel()
        {
            Student = new Student();
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public event Action<IDialogResult> RequestClose;

        private async Task AddStudent()
        {
            Student.Exams = new List<Exam>();
            Student.Retakes = new List<Retake>();
            await StudentService.AddAsync(Student);
        }

        protected virtual async void CloseDialog(string parameter)
        {
            ButtonResult result = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                await AddStudent();
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
        }
    }
}
