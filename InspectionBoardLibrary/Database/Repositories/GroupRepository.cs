using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Linq;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class GroupRepository : EfRepository<Group, ExamContext>
    {
        public GroupRepository(ExamContext context) : base(context)
        {

        }

        internal bool TableIsEmpty()
        {
            return !context.Groups.Any();
        }
    }
}
