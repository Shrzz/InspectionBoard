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
    public static class TeacherServiceExtensions
    {
        public static List<Category> SelectEducationForms(this TeacherService service)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Categories.AsNoTracking().ToList();
            }
        }
    }
}
