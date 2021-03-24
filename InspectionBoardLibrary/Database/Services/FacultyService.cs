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

        public async Task EditAsync(Faculty o)
        {
            using (ExamContext context = new ExamContext())
            {
                var oldFaculty = await context.Faculties.FirstOrDefaultAsync(f => f.Id == o.Id);
                if (oldFaculty != null && o != null)
                {
                    oldFaculty.Name = o.Name;
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var facultyToRemove = await context.Faculties.FirstOrDefaultAsync(f => f.Id == id);
                if (facultyToRemove != null)
                {
                    context.Faculties.Remove(facultyToRemove);
                }

                await context.SaveChangesAsync();
            }
        }

        public List<Faculty> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.OrderBy(s => s.Id).ToListAsync().Result;
            }
        }

        public List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.OrderBy(f => f.Id).Select(f => f.Id).ToListAsync().Result;
            }
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
