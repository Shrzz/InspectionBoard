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
    public static class ExamServiceExtensions
    {
        public static List<ExamForm> SelectExamForms(this ExamService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.ExamForms.AsNoTracking().ToList();
            }
        }

        public static List<ExamType> SelectExamTypes(this ExamService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.ExamTypes.AsNoTracking().ToList();
            }
        }

        public static List<Student> SelectStudents(this ExamService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Students.AsNoTracking().ToList();
            }
        }

        public static List<Teacher> SelectTeachers(this ExamService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Teachers.AsNoTracking().ToList();
            }
        }

        public static List<Subject> SelectSubjects(this ExamService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Subjects.AsNoTracking().ToList();
            }
        }
    }
}
