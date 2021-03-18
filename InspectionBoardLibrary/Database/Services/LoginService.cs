using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public static class LoginService
    {
        public async static Task<bool> TryLogin(string login, string password)
        {
            User a;
            using (UserContext context = new UserContext())
            {
                a = await context.Users.FirstOrDefaultAsync(u => u.Username == login && u.Password == password);
            }

            return a != null;
        }
    }
}
