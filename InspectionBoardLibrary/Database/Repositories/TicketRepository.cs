using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class TicketRepository : EfRepository<Ticket, ExamContext>
    {
        public TicketRepository(ExamContext context) : base(context)
        {

        }

        public async Task<ObservableCollection<Subject>> SelectSubjects()
        {
            var collection = await context.Subjects.ToListAsync();
            return new ObservableCollection<Subject>(collection);
        }
    }
}
