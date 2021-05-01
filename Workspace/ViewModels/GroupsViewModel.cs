﻿using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Domain.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class GroupsViewModel : TablePage<Group, ExamContext>
    {
        public GroupsViewModel(IDialogService service, GroupRepository repository, GroupSearcher searcher) : base(service, repository, searcher)
        {

        }
    }
}
