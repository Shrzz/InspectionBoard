using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public static class UserService
    {
        public async static Task AddUser(User u)
        {
            using (UserContext context = new UserContext())
            {
                context.Users.Add(u);
                await context.SaveChangesAsync();
            }
        }
    }
}
