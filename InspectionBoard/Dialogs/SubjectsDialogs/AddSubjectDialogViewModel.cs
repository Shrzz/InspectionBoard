using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;

namespace InspectionBoard.Dialogs.SubjectsDialogs
{
    public class AddSubjectDialogViewModel : AddDialogViewModel<Subject, ExamContext>
    {
        public AddSubjectDialogViewModel(SubjectRepository repository) : base(repository) 
        { 

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Entity = new Subject();
        }
    }
}
