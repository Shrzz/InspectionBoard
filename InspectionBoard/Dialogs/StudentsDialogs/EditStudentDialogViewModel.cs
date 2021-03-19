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
    public class EditStudentDialogViewModel : BindableBase, IDialogAware
    {
        private IDialogParameters dialogParameters;

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
            get => new ObservableCollection<int>(StudentService.SelectIds());
        }

        public ObservableCollection<Faculty> Faculties
        {
            get => new ObservableCollection<Faculty>(FacultyService.Select());
        }

        public ObservableCollection<EducationForm> EducationForms
        {
            get => new ObservableCollection<EducationForm>(EducationFormService.Select());
        }

        public string Title => "Изменить данные студента";
        public DelegateCommand<string> CloseDialogCommand { get; private set; }

        public EditStudentDialogViewModel()
        {
            Student = new Student();
            CloseDialogCommand = new DelegateCommand<string>(CloseDialog);
        }

        public event Action<IDialogResult> RequestClose;

        private async Task EditStudent()
        {
            if (Student.Exams is null)
            {
                Student.Exams = new List<Exam>();
            }

            if (Student.Retakes is null)
            {
                Student.Retakes = new List<Retake>();
            }

            await StudentService.EditAsync(Student);
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
        }
    }
}