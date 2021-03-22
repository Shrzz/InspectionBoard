using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class UserService : IDatabaseService<User>
    {
        public async Task AddAsync(User u)
        {
            using (UserContext context = new UserContext())
            {
                var user = context.Users.FirstOrDefault(s => s.Username == u.Username);
                if (user is null)
                {
                    context.Users.Add(u);
                    await context.SaveChangesAsync();
                }
            }
        }

        public Task EditAsync(User o)
        {
            throw new NotImplementedException();
        }

        public bool TableIsEmpty()
        {
            using (UserContext context = new UserContext())
            {
                return !context.Users.Any();
            }
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> Select()
        {
            throw new NotImplementedException();
        }

        public List<int> SelectIds()
        {
            throw new NotImplementedException();
        }
    }
}
