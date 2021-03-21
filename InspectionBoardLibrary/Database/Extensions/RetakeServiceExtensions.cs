using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Extensions
{
    public static class RetakeServiceExtensions
    {
        public static List<Student> SelectStudents(this RetakeService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.AsNoTracking().ToList();
            }
        }

        public static List<Teacher> SelectTeachers(this RetakeService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Teachers.AsNoTracking().ToList();
            }
        }

        public static List<Subject> SelectSubjects(this RetakeService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Subjects.AsNoTracking().ToList();
            }
        }
    }
}
