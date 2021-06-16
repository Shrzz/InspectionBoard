using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Dialogs.JournalDialogs
{
    public class RemoveJournalDialogViewModel : RemoveDialogViewModel<Journal, ExamContext>
    {

        public RemoveJournalDialogViewModel(IRepository<Journal> repository) : base(repository)
        {

        }

        public async override void CloseDialog(string parameter)
        {
            base.CloseDialog(parameter);
        }
    }
}
