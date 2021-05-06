﻿using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Dialogs.TicketsDialogs
{
    public class AddTicketDialogViewModel : AddDialogViewModel<Ticket, ExamContext>
    {
        public AddTicketDialogViewModel(IRepository<Ticket> repository) : base(repository)
        {

        }
    }
}
