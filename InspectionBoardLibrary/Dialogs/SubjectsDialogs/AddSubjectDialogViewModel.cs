using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Models.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace InspectionBoardLibrary.Windows.SubjectsDialogs
{
    public class AddSubjectDialogViewModel : AddDialogViewModel<Subject, ExamContext>
    {
        public AddSubjectDialogViewModel(IRepository<Subject> repository) : base(repository) 
        { 

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            dialogParameters = parameters;
            Entity = new Subject();
        }
    }
}
