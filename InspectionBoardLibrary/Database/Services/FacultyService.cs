using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public static class FacultyService
    {
        public async static Task AddSync(Faculty o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Faculties.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public static List<Faculty> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.AsNoTracking().AsNoTracking().ToListAsync().Result;
            }
        }
    }
}
