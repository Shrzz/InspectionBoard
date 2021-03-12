using InspectionBoardLibrary.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.DatabaseHandler
{
    public static class Dbc
    {
        public async static Task AddApplicant(Student student)
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

        public async static Task<List<Student>> GetStudentList()
        {
            using (ExamContext context = new ExamContext())
            {
                return await context.Students.AsNoTracking().ToListAsync();
            }
        }

        public async static Task<List<Faculty>> GetFacultiesList()
        {
            using (ExamContext context = new ExamContext())
            {
                return await context.Faculties.AsNoTracking().ToListAsync();
            }
        }

        public async static Task<List<User>> GetUserList()
        {
            using (UserContext context = new UserContext())
            {
                return await context.Users.AsNoTracking().ToListAsync();
            }
        }
    }
}
