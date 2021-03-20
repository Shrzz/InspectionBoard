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
                return context.Faculties.OrderBy(s => s.Id).Distinct().ToListAsync().Result;
            }
        }

        public static Faculty SelectById(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var f = context.Faculties.FirstOrDefault(s => s.Id == id);
                return f;
            }
        }
    }
}
