using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class TeacherRepository : EfRepository<Teacher, ExamContext>
    {
        public TeacherRepository(ExamContext context) : base(context)
        {

        }

        public async Task<List<Group>> SelectGroups()
        {
            return await context.Groups.AsNoTracking().ToListAsync();
        }
    }
}
