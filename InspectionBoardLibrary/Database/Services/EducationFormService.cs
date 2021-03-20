using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public static class EducationFormService
    {
        public static List<EducationForm> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.EducationForms.OrderBy(s => s.Id).ToList();
            }
        }

        public static EducationForm SelectById(int id)
        {
            using (ExamContext context = new ExamContext())
            {
                return context.EducationForms.FirstOrDefault(s => s.Id == id);
            }
        }
    }
}
