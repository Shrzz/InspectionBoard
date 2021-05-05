using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.Database;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Linq;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class UserRepository : EfRepository<User, ExamContext>
    {
        public UserRepository(ExamContext context) : base(context)
        {

        }

        internal bool TableIsEmpty()
        {
            return !context.Users.Any<User>();
        }
    }
}
