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
                context.Students.Attach(o.Student);
                context.Subjects.Attach(o.Subject);
                context.Teachers.Attach(o.Teacher);
                context.Retakes.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Retake o)
        {
            using (ExamContext context = new ExamContext())
            {
                var newRetake = await context.Retakes.FirstOrDefaultAsync(s => s.Id == o.Id);
                if (o != null && newRetake != null)
                {
                    newRetake.Student = o.Student;
                    newRetake.Subject = o.Subject;
                    newRetake.Teacher = o.Teacher;
                    newRetake.DateTime = o.DateTime;
                    context.Students.Attach(o.Student);
                    context.Teachers.Attach(o.Teacher);
                    context.Subjects.Attach(o.Subject);
                }

                await context.SaveChangesAsync();
            }
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
                return context.Retakes.AsNoTracking().Include(r => r.Student).Include(r => r.Subject).Include(r => r.Teacher).ToList();
            }
        }

        public List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Retakes.AsNoTracking().Select(r => r.Id).ToList();
            }
        }

        public bool TableIsEmpty()
        {
            using (ExamContext context = new ExamContext())
            {
                return !context.Retakes.Any();
            }
        }
    }
}
