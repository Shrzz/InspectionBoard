using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Dialogs.TicketsDialogs
{
    public class EditTicketDialogViewModel : EditDialogViewModel<Ticket, ExamContext>
    {
        public EditTicketDialogViewModel(IRepository<Ticket> repository) : base(repository)
        {

        }
    }
}
