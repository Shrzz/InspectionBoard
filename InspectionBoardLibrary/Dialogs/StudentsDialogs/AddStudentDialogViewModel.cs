using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace InspectionBoardLibrary.Windows.StudentsDialogs
{
    public class AddStudentDialogViewModel : AddDialogViewModel<Student, ExamContext>
    {

        private ObservableCollection<string> educationForms;
        public ObservableCollection<string> EducationForms 
        {
            get => educationForms;
            set { SetProperty(ref educationForms, value); }
        }

        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get => groups;
            set { SetProperty(ref groups, value); }
        }

        public AddStudentDialogViewModel(IRepository<Student> repository) : base(repository)
        {

        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            EducationForms = new ObservableCollection<string>(Enum.GetNames(typeof(EducationForm)));
            Groups = await (repository as StudentRepository).SelectGroups();
            this.Entity = new Student();
        }
    }
}
