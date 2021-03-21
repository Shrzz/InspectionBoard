using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class RetakeService : IDatabaseService<Retake>
    {
        public async Task AddAsync(Retake o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Retakes.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Retake o)
        {
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var retakeToRemove = await context.Retakes.FirstOrDefaultAsync(r => r.Id == id);
                context.Retakes.Remove(retakeToRemove);
                await context.SaveChangesAsync();
            }
        }

        public List<Retake> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Retakes.AsNoTracking().ToList();
            }
        }

        public List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Retakes.AsNoTracking().Select(r => r.Id).ToList();
            }
        }
    }
}
