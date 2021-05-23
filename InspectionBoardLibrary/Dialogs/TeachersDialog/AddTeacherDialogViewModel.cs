using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using InspectionBoardLibrary.Models.Enums;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InspectionBoardLibrary.Windows.TeachersDialog
{
    public class AddTeacherDialogViewModel : AddDialogViewModel<Teacher, ExamContext>
    {
        //entity properties
        private string surname;
        public string Surname { get => surname; set { SetProperty(ref surname, value); } }

        private string name;
        public string Name { get => name; set { SetProperty(ref name, value); } }

        private string patronymic;
        public string Patronymic { get => patronymic; set { SetProperty(ref patronymic, value); } }

        private Category category;
        public Category Category { get => category; set { SetProperty(ref category, value); } }

        //values collections
        private IList<Category> categories;
        public IList<Category> Categories
        {
            get => categories;
            set { SetProperty(ref categories, value); }
        }

        public AddTeacherDialogViewModel(IRepository<Teacher> repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;
            Categories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
        }

        public override void CloseDialog(string parameter)
        {
            Entity = new Teacher();
            Entity.Surname = Surname;
            Entity.Name = Name;
            Entity.Patronymic = Patronymic;
            Entity.Category = Category.ToString();

            base.CloseDialog(parameter);
        }
    }
}
