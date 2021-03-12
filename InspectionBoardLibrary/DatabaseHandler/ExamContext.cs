using InspectionBoardLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionBoardLibrary.DatabaseHandler
{
    public class ExamContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<EducationForm> EducationForms { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamForm> ExamForms { get; set; }
        public DbSet<ExamType> ExamTypes { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Retake> Retakes { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<User> Users { get; set; }

        public ExamContext() : base("DbConnection")
        {

        }



    }
}
