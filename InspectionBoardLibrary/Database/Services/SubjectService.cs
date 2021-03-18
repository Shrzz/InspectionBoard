using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace InspectionBoardLibrary.Database.Services
{
    public static class SubjectService
    {
        public static async Task AddAsync(Subject o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Subjects.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public static async Task EditAsync(Subject o)
        {
            using (ExamContext context = new ExamContext())
            {
                var newSubject = await context.Subjects.FirstOrDefaultAsync(s => s.Id == o.Id);
                if (o != null)
                {
                    //newSubject.Name = o.Name;
                    //newSubject.Patronymic = o.Patronymic;
                    //newSubject.Retakes = o.Retakes;
                    //newSubject.Surname = o.Surname;
                    //newSubject.Exams = o.Exams;
                    //newSubject.Faculty = o.Faculty;
                    //newSubject.EducationForm = o.EducationForm;
                    //context.Students.Add(o);
                }

                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveAsync(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var subjectToRemove = await context.Subjects.FirstOrDefaultAsync(s => s.Id == id);
                if (subjectToRemove != null)
                {
                    context.Subjects.Remove(subjectToRemove);
                }
            }
        }

        public static List<Subject> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Subjects.AsNoTracking().ToList();
            }
        }
    }
}
