using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.Database
{
    public static class Dbc
    {

        public async static Task AddFaculty(Faculty faculty)
        {
            using (ExamContext context = new ExamContext())
            {
                context.Faculties.Add(faculty);
                await context.SaveChangesAsync();
            }
        }
        public static List<Faculty> GetFacultiesList()
        {
            using (ExamContext context = new ExamContext())
            {
                return context.Faculties.AsNoTracking().AsNoTracking().ToListAsync().Result;
            }
        }

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
