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

        public static async Task EditAsync(Student newStudent)
        {
            using (ExamContext context = new ExamContext())
            {
                var oldStudent = await context.Students.FirstOrDefaultAsync(s => s.Id == newStudent.Id);
                if (oldStudent != null && newStudent != null)
                {
                    oldStudent.Name = newStudent.Name;
                    oldStudent.Patronymic = newStudent.Patronymic;
                    oldStudent.Retakes = newStudent.Retakes;
                    oldStudent.Surname = newStudent.Surname;
                    oldStudent.Exams = newStudent.Exams;
                    oldStudent.Faculty = newStudent.Faculty;// FacultyService.SelectById(newStudent.Faculty.Id);
                    oldStudent.EducationForm = EducationFormService.SelectById(newStudent.Faculty.Id);
                    if (oldStudent.Faculty.Students is null) 
                    {
                        oldStudent.Faculty.Students = new List<Student> { oldStudent };
                    }
                    else 
                    {
                        oldStudent.Faculty.Students.Add(oldStudent);
                    }
                }
                context.SaveChanges();
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
                    await context.SaveChangesAsync();
                }
            }
        }

        public static List<Student> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.Include(a => a.Faculty).Include(s => s.EducationForm).OrderBy(s => s.Id).ToList();
            }
        }

        public static List<int> SelectIds()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.OrderBy(s => s.Id).Select(s => s.Id).ToList();
            }
        }
    }
}
