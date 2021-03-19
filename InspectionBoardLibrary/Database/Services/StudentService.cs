using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public static class StudentService 
    {
        public static async Task AddAsync(Student o)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Students.Add(o);
                await context.SaveChangesAsync();
            }
        }

        public static async Task EditAsync(Student o)
        {
            using (ExamContext context = new ExamContext())
            {
                var newStudent = await context.Students.Include(s => s.Faculty).Include(s => s.EducationForm).FirstOrDefaultAsync(s => s.Id == o.Id);
                if (o != null)
                {
                    newStudent.Name = o.Name;
                    newStudent.Patronymic = o.Patronymic;
                    newStudent.Retakes = o.Retakes;
                    newStudent.Surname = o.Surname;
                    newStudent.Exams = o.Exams;
                    newStudent.Faculty = o.Faculty;
                    newStudent.EducationForm = o.EducationForm;
                    context.Students.Add(o);
                }

                await context.SaveChangesAsync();
            }
        }

        public static async Task RemoveAsync(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var studentToRemove = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
                if (studentToRemove != null)
                {
                    context.Students.Remove(studentToRemove);
                }
            }
        }

        public static List<Student> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.Include(a => a.Faculty).Include(s => s.EducationForm).ToList();
            }
        }

        public static List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.Select(s => s.Id).ToList();
            }
        }
    }
}
