using InspectionBoardLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.DatabaseHandler
{
    public static class Dbc
    {
        public async static Task AddStudent(Student student)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Students.Add(student);
                await context.SaveChangesAsync();
            }
        }

        public async static Task RemoveStudent(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                var student = await context.Students.FirstOrDefaultAsync(s => s.Id == id);

                if (student != null)
                {
                    context.Students.Remove(student);
                }
            }
        }

        public async static Task EditStudent(Student newStudent)
        {
            using (ExamContext context = new ExamContext())
            {
                var student = await context.Students.FirstOrDefaultAsync(s => s.Id == newStudent.Id);

                if (student != null)
                {
                    student.Name = newStudent.Name;
                    student.Patronymic = newStudent.Patronymic;
                    student.Retakes = newStudent.Retakes;
                    student.Surname = newStudent.Surname;
                    student.Exams = newStudent.Exams;
                    student.Faculty = newStudent.Faculty;
                    student.EducationForm = newStudent.EducationForm;
                }

                await context.SaveChangesAsync();
            }
        }

        public static List<Student> GetStudentList()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.AsNoTracking().ToListAsync().Result;
            }
        }

        public static List<Faculty> GetFacultiesList()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.AsNoTracking().ToListAsync().Result;
            }
        }


        public static bool TryLogin(string login, string password)
        {
            User a;
            using (UserContext context = new UserContext())
            {
                a = context.Users.FirstOrDefaultAsync(u => u.Username == login && u.Password == password).Result;
            }

            return a != null;
        }
    }
}
