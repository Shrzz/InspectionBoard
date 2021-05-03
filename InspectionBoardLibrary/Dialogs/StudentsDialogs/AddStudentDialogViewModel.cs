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

        private IList<EducationForm> educationForms;
        public IList<EducationForm> EducationForms
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
            EducationForms = Enum.GetValues(typeof(EducationForm)).Cast<EducationForm>().ToList<EducationForm>();
            Groups = await (repository as StudentRepository).SelectGroups();
            this.Entity = new Student();
            Entity.Group = Groups[0];
        }
    }
}
