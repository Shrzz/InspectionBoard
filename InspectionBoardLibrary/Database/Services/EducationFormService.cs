using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class EducationFormService : IDatabaseService<EducationForm>
    {
        public Task AddAsync(EducationForm o)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(EducationForm o)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<EducationForm> Select()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.EducationForms.OrderBy(s => s.Id).ToList();
            }
        }

        public List<int> SelectIds()
        {
            throw new NotImplementedException();
        }
    }
}
