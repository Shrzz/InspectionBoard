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
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Windows.StudentsDialogs
{
    public class EditStudentDialogViewModel : EditDialogViewModel<Student, ExamContext>
    {
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

        public EditStudentDialogViewModel(IRepository<Student> repository) : base(repository)
        {
            Groups = new ObservableCollection<Group>();
        }

        public override async Task EditEntity()
        {
            if (Entity != null)
            {
                await repository.Update(Entity);
            }
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            DialogOpened();
        }

        public async Task DialogOpened()
        {
            EducationForms = Enum.GetValues(typeof(EducationForm)).Cast<EducationForm>().ToList();
            Groups = await (repository as StudentRepository).SelectGroupsAsync();
        }
    }
}
