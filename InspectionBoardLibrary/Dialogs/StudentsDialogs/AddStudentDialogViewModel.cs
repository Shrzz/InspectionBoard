using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InspectionBoardLibrary.Windows.StudentsDialogs
{
    public class AddStudentDialogViewModel : AddDialogViewModel<Student, ExamContext>
    {
        // Entity properties
        private string surname;
        public string Surname { get => surname; set { SetProperty(ref surname, value); } }

        private string name;
        public string Name { get => name; set { SetProperty(ref name, value); } }

        private string patronymic;
        public string Patronymic { get => patronymic; set { SetProperty(ref patronymic, value); } }

        private Group group;
        public Group Group { get => group; set { SetProperty(ref group, value); } }

        private EducationForm educationForm;
        public EducationForm EducationForm { get => educationForm; set { SetProperty(ref educationForm, value); } }

        // Values collections
        private ObservableCollection<Group> groups;
        public ObservableCollection<Group> Groups
        {
            get => groups;
            set { SetProperty(ref groups, value); }
        }

        private IList<EducationForm> educationForms;
        public IList<EducationForm> EducationForms
        {
            get => educationForms;
            set { SetProperty(ref educationForms, value); }
        }

        public AddStudentDialogViewModel(IRepository<Student> repository) : base(repository)
        {

        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;
            Groups = await (repository as StudentRepository).SelectGroups();
            EducationForms = Enum.GetValues(typeof(EducationForm)).Cast<EducationForm>().ToList();
        }

        public override void CloseDialog(string parameter)
        {
            Entity = new Student();
            Entity.Surname = Surname;
            Entity.Name = Name;
            Entity.Patronymic = Patronymic;
            Entity.Group = Group;
            Entity.EducationForm = EducationForm;

            base.CloseDialog(parameter);
        }
    }
}
