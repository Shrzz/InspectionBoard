using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class GroupService : IDatabaseService<Group>
    {
        public async Task AddAsync(Group o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Groups.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public Task EditAsync(Group o)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Group> Select()
        {
            throw new NotImplementedException();
        }

        public List<int> SelectIds()
        {
            throw new NotImplementedException();
        }

        public bool TableIsEmpty()
        {
            throw new NotImplementedException();
        }
    }
}
