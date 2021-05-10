using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Services.Dialogs;

namespace Tickets.ViewModels
{
    public class MainViewModel : TablePage<Ticket, ExamContext>
    {
        public MainViewModel(IDialogService service, IRepository<Ticket> repository) : base(service, repository)
        {

        }
    }
}
