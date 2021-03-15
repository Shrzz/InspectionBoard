using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.GridModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database
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

        public async static Task EditStudent(Student newStudent)
        {
            using (ExamContext context = new ExamContext())
            {
                var student = await context.Students.Include(s => s.Faculty).FirstOrDefaultAsync(s => s.Id == newStudent.Id);

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

        public async static void AddFaculty(Faculty faculty)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Faculties.Add(faculty);
                await context.SaveChangesAsync();
            }
        }

        public static List<Student> GetStudentList()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.Include(s => s.Faculty).AsNoTracking().ToListAsync().Result;
            }
        }

        public static List<Faculty> GetFacultiesList()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.AsNoTracking().ToListAsync().Result;
            }
        }

        public static List<Teacher> GetTeachersList()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Teachers.Include(t => t.Category).AsNoTracking().ToListAsync().Result;
            }
        }

        public static List<Subject> GetSubjectsList()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Subjects.AsNoTracking().ToListAsync().Result;
            }
        }

        public async static Task AddUser(User u )
        {
            using (UserContext context = new UserContext())
            {
                context.Users.Add(u);
                await context.SaveChangesAsync();
            }
        }

        public async static Task<bool> TryLogin(string login, string password)
        {
            User a;
            using (UserContext context = new UserContext())
            {
                a = await context.Users.FirstOrDefaultAsync(u => u.Username == login && u.Password == password);
            }

            return a != null;
        }
    }
}
