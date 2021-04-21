using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Database.Domain;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Linq;

namespace InspectionBoardLibrary.Database.Repositories
{
    public class UserRepository : EfRepository<User, UserContext>
    {
        public UserRepository(UserContext context) : base(context)
        {

        }

        internal bool TableIsEmpty()
        {
            return !context.Users.Any<User>();
        }
    }
}
