using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Dialogs.TicketsDialogs
{
    public class RemoveTicketDialogViewModel : RemoveDialogViewModel<Ticket, ExamContext>
    {
        public RemoveTicketDialogViewModel(IRepository<Ticket> repository) : base(repository)
        {

        }
    }
}
