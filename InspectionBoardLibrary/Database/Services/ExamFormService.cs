using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class ExamFormService : IDatabaseService<ExamForm>
    {
        public async Task AddAsync(ExamForm o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.ExamForms.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public Task EditAsync(ExamForm o)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<ExamForm> Select()
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
                return !context.ExamForms.Any();
            }
        }
    }
}
