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
    public class ExamService : IDatabaseService<Exam>
    {
        public async Task AddAsync(Exam o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Students.Attach(o.Student);
                context.Teachers.Attach(o.Teacher);
                context.Exams.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditAsync(Exam o)
        {
            using (ExamContext context = new ExamContext())
            {
                var oldExam = await context.Exams.FirstOrDefaultAsync(e => e.Id == o.Id);
                if (o != null && oldExam != null)
                {
                    oldExam.Student = o.Student;
                    oldExam.Subject = o.Subject;
                    oldExam.Teacher = o.Teacher;
                    oldExam.Date = o.Date;
                    oldExam.ExamForm = o.ExamForm;
                    oldExam.ExamType = o.ExamType;

                    context.Students.Attach(oldExam.Student);
                    context.Teachers.Attach(oldExam.Teacher);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task RemoveAsync(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var examToRemove = await context.Exams.FirstOrDefaultAsync(e => e.Id == id);
                context.Exams.Remove(examToRemove);
                await context.SaveChangesAsync();
            }
        }

        public List<Exam> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Exams.
                    Include(e => e.ExamForm).
                    Include(e => e.ExamType).
                    Include(e => e.Student).
                    Include(e => e.Teacher).
                    Include(e => e.Subject).
                    OrderBy(e => e.Id).
                    ToList();
            }
        }

        public List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Exams.AsNoTracking().OrderBy(e => e.Id).Select(e => e.Id).ToList();
            }
        }

        public bool TableIsEmpty()
        {
            using (ExamContext context = new ExamContext())
            {
                return !context.Exams.Any();
            }
        }
    }
}
