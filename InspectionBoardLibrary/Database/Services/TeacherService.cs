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
    public static class TeacherService
    {
        public static async Task AddAsync(Teacher o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Teachers.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public static async Task EditAsync(Teacher o)
        {
            using (ExamContext context = new ExamContext())
            {
                var newStudent = await context.Teachers.Include(s => s.Category).FirstOrDefaultAsync(s => s.Id == o.Id);
                if (o != null)
                {
                    newStudent.Surname = o.Surname;
                    newStudent.Name = o.Name;
                    newStudent.Patronymic = o.Patronymic;
                    newStudent.Category = o.Category;
                    newStudent.Exams = o.Exams;
                    context.Teachers.Add(o);
                }

                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveAsync(int id)
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

        public static List<Teacher> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Teachers.Include(s => s.Category).AsNoTracking().ToList();
            }
        }
    }
}
