using InspectionBoardLibrary.Models;
using InspectionBoardLibrary.Models.DatabaseModels;
using System.Data.Entity;

namespace InspectionBoardLibrary.Database
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base("DbConnection")
        {

        }
    }
}
