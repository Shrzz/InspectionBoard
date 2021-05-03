using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class SubjectRepository : EfRepository<Subject, ExamContext>
    {
        public SubjectRepository(ExamContext context) : base(context)
        {

        }
    }
}
