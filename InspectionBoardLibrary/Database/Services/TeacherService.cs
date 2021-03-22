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
    public class TeacherService : IDatabaseService<Teacher>
    {
        public async Task AddAsync(Teacher o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Categories.Attach(o.Category);
                context.Teachers.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Teacher o)
        {
            using (ExamContext context = new ExamContext())
            {
                var newTeacher = await context.Teachers.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == o.Id);
                if (o != null)
                {
                    newTeacher.Surname = o.Surname;
                    newTeacher.Name = o.Name;
                    newTeacher.Patronymic = o.Patronymic;
                    newTeacher.Category = o.Category;
                    context.Categories.Attach(newTeacher.Category);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var objectToRemove = await context.Teachers.FirstOrDefaultAsync(s => s.Id == id);
                if (objectToRemove != null)
                {
                    context.Teachers.Remove(objectToRemove);
                    await context.SaveChangesAsync();
                }
            }
        }

        public List<Teacher> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Teachers.Include(s => s.Category).AsNoTracking().OrderBy(t => t.Id).ToList();
            }
        }

        public List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Teachers.AsNoTracking().OrderBy(t => t.Id).Select(t => t.Id).ToList();
            }
        }

        public bool TableIsEmpty()
        {
            using (ExamContext context = new ExamContext())
            {
                return !context.Teachers.Any();
            }
        }
    }
}
