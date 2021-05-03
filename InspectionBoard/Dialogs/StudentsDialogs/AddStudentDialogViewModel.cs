using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InspectionBoard.Dialogs.StudentsDialogs
{
    public class AddStudentDialogViewModel : AddDialogViewModel<Student, ExamContext>
    {
        public AddStudentDialogViewModel(StudentRepository repository) : base(repository)
        {

        }

        public ObservableCollection<string> EducationForms 
        { 
            get => new ObservableCollection<string>(Enum.GetNames(typeof(EducationForm)));
        }

        public ObservableCollection<Group> Groups
        {
            get => (repository as StudentRepository).SelectGroups().Result;
        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            this.Entity = new Student();
        }
    }
}
