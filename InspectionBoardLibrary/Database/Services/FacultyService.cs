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
    public class FacultyService : IDatabaseService<Faculty>
    {
        public async Task AddAsync(Faculty o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Faculties.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public Task EditAsync(Faculty o)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<Faculty> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.OrderBy(s => s.Id).Distinct().ToListAsync().Result;
            }
        }

        public List<int> SelectIds()
        {
            throw new NotImplementedException();
        }

        public bool TableIsEmpty()
        {
            using (ExamContext context = new ExamContext())
            {
                return !context.Faculties.Any();
            }
        }
    }
}
