﻿using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Windows.ExamsDialogs
{
    public class EditGroupDialogViewModel : EditDialogViewModel<Group, ExamContext>
    {
        public EditGroupDialogViewModel(GroupRepository repository) : base(repository)
        {

        }
    }
}