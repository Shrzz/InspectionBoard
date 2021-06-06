using InspectionBoardLibrary.Database.Contexts;
using InspectionBoardLibrary.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database.Services
{
    public class LoginService
    {
        public async Task<User> TryLogin(string login, string password)
        {
            User a;
            using (ExamContext context = new ExamContext())
            {
                a = await context.Users.FirstOrDefaultAsync(u => u.Username == login && u.Password == password);
            }

            return a;
        }

    }
}
