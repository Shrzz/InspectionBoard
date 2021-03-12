using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using InspectionBoardLibrary.Models;

namespace InspectionBoardLibrary.DatabaseHandler
{
    public class ExaminationContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }
        public DbSet<User> Users { get; set; }

        public ExaminationContext() : base("DefaultConnection")
        {
            // Database.SetInitializer<ExaminationContext>(new DropCreateDatabaseAlways<ExaminationContext>());
        }
        
    }
}
