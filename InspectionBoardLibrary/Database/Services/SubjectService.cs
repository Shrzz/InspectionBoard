using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class SubjectService : IDatabaseService<Subject>
    {
        public async Task AddAsync(Subject o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Subjects.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Subject o)
        {
            using (ExamContext context = new ExamContext())
            {
                var newSubject = await context.Subjects.FirstOrDefaultAsync(s => s.Id == o.Id);
                if (o != null && newSubject != null)
                {
                    newSubject.Name = o.Name;
                    newSubject.LectoryHours = o.LectoryHours;
                    newSubject.LaboratoryHours = o.LaboratoryHours;
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var subjectToRemove = await context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
                if (subjectToRemove != null)
                {
                    context.Subjects.Remove(subjectToRemove);
                    await context.SaveChangesAsync();
                }
            }
        }

        public List<Subject> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Subjects.AsNoTracking().ToList();
            }
        }

        public List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Subjects.OrderBy(s => s.Id).Select(s => s.Id).ToList();
            }
        }
    }
}
