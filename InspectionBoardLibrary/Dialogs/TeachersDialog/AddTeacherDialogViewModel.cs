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
        public AddTeacherDialogViewModel(IRepository<Teacher> repository) : base(repository)
        {

        }

        private IList<Category> categories;
        public IList<Category> Categories
        {
            get => categories;
            set { SetProperty(ref categories, value); }
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            this.Entity = new Teacher();
            Categories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList<Category>();
        }
    }
}
