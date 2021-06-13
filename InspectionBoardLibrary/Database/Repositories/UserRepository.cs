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

        public User GetUser(string username, string password)
        {
            return context.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower() && u.Password == password);
        }

        public bool UsernameIsTaken(string username)
        {
            var user = context.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());
            return !(user is null);
        }
    }
}
