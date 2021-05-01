﻿using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Repositories;
using InspectionBoardLibrary.Domain.Searchers;
using InspectionBoardLibrary.Domain.ViewModels.Pages;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class SubjectsViewModel : TablePage<Subject, ExamContext>
    {
        public SubjectsViewModel(IDialogService service, SubjectRepository repository, SubjectSearcher searcher) : base(service, repository, searcher)
        {

        }
    }
}
