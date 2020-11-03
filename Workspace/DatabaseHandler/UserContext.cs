using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workspace.Models;

namespace Workspace.DatabaseHandler
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public UserContext() : base("DefaultConnection")
        {
    		Database.SetInitializer(new DropCreateDatabaseIfModelChanges<UserContext>());
        }
    }
}
