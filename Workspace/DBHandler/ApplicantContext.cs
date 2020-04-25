using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Workspace.Models;

namespace Workspace.DBHandler
{
    public class ApplicantContext : DbContext
    {
        public DbSet<Applicant> Applicants { get; set; }

        public ApplicantContext() : base("DefaultConnection")
        {

        }
        
    }
}
