using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using InspectionBoardLibrary.Database.Domain;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class SubjectRepository : EfRepository<Subject, ExamContext>
    {
        public SubjectRepository(ExamContext context) : base(context)
        {

        }
    }
}
