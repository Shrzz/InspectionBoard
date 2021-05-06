using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets.ViewModels
{
    public class MainViewModel : TablePage<Ticket, ExamContext>
    {
        public MainViewModel(IDialogService service, IRepository<Ticket> repository) : base(service, repository)
        {

        }


    }
}
