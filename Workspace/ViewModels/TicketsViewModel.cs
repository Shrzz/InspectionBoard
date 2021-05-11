using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Workspace.ViewModels
{
    public class TicketsViewModel : TablePage<Ticket, ExamContext>
    {
        public TicketsViewModel(IDialogService service, IRepository<Ticket> repository) : base(service, repository)
        {

        }
    }
}
