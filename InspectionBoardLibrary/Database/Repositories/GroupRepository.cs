using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InspectionBoardLibrary.Database.Domain;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class GroupRepository : EfRepository<Group, ExamContext>
    {
        public GroupRepository(ExamContext context) : base(context)
        {

        }

        internal bool TableIsEmpty()
        {
            return !context.Groups.Any();
        }

        public async Task<ObservableCollection<int>> SelectIds()
        {
            var collection = await context.Groups.OrderBy(g => g.Id).Select(g => g.Id).ToListAsync();
            return new ObservableCollection<int>(collection);
        }
    }
}
