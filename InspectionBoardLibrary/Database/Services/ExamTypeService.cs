using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class ExamTypeService : IDatabaseService<ExamType>
    {
        public async Task AddAsync(ExamType o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.ExamTypes.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public Task EditAsync(ExamType o)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExamType> Select()
        {
            throw new NotImplementedException();
        }

        public List<int> SelectIds()
        {
            throw new NotImplementedException();
        }

        public bool TableIsEmpty()
        {
            using (ExamContext context = new ExamContext())
            {
                return !context.ExamTypes.Any();
            }
        }
    }
}
