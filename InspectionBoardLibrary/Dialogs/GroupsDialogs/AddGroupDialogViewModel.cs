using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Domain.ViewModels.Dialogs;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Windows.GroupsDialogs
{
    public class AddGroupDialogViewModel : AddDialogViewModel<Group, ExamContext>
    {
        public AddGroupDialogViewModel(GroupRepository repository) : base(repository)
        {

        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            this.dialogParameters = parameters;
            Entity = new Group();
        }
    }
}
