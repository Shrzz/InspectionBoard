using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Services.Dialogs;
using System;
using System.Collections.ObjectModel;

namespace InspectionBoardLibrary.Windows.StudentsDialogs
{
    public class EditStudentDialogViewModel : EditDialogViewModel<Student, ExamContext>
    {
        private IDialogParameters dialogParameters;
        private readonly IRepository<Student> repository;

        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get => groups;
            set { SetProperty(ref groups, value); }
        }

        private ObservableCollection<string> educationForms;
        public ObservableCollection<string> EducationForms
        {
            get => educationForms;
            set { SetProperty(ref educationForms, value); }
        }
        public EditStudentDialogViewModel(IRepository<Student> repository) : base(repository)
        {

        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            Groups = await (repository as GroupRepository).Select();
            EducationForms = new ObservableCollection<string>(Enum.GetNames(typeof(EducationForm)));
        }
    }
}
