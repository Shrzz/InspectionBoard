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

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class EditTeacherDialogViewModel : EditDialogViewModel<Teacher, ExamContext>
    {
        private IList<Category> categories;
        public IList<Category> Categories
        {
            get => categories;
            set { SetProperty(ref categories, value); }
        }

        public EditTeacherDialogViewModel(IRepository<Teacher> repository) : base(repository)
        {

        }

        public override async void OnDialogOpened(IDialogParameters parameters)
        {
            base.OnDialogOpened(parameters);
            Categories = Enum.GetValues(typeof(Category)).Cast<Category>().ToList();
        }
    }
}

