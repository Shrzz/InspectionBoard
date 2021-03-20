using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Services;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Extensions
{
    public static class StudentServiceExtensions
    {
        public static List<Faculty> SelectFaculties(this StudentService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.AsNoTracking().ToList();
            }
        }

        public static List<EducationForm> SelectEducationForms(this StudentService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.EducationForms.AsNoTracking().ToList();
            }
        }
    }
}
