﻿using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Domain;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoard.Dialogs.SubjectsDialogs
{
    public class RemoveSubjectDialogViewModel : RemoveDialogViewModel<Subject, ExamContext>
    {
        public RemoveSubjectDialogViewModel(IRepository<Subject> repository) : base(repository)
        {

        }
    }
}
