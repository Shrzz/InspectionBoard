namespace InspectionBoardLibrary.ExamContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Multiplier = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EducationForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Form = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ExamForms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Form = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Mark = c.Int(nullable: false),
                        ExamForm_Id = c.Int(),
                        ExamType_Id = c.Int(),
                        Student_Id = c.Int(),
                        Subject_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamForms", t => t.ExamForm_Id)
                .ForeignKey("dbo.ExamTypes", t => t.ExamType_Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.ExamForm_Id)
                .Index(t => t.ExamType_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.ExamTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        EducationForm_Id = c.Int(),
                        Faculty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EducationForms", t => t.EducationForm_Id)
                .ForeignKey("dbo.Faculties", t => t.Faculty_Id)
                .Index(t => t.EducationForm_Id)
                .Index(t => t.Faculty_Id);
            
            CreateTable(
                "dbo.Faculties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Retakes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        Student_Id = c.Int(),
                        Subject_Id = c.Int(),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lectory_hours = c.Int(nullable: false),
                        Laboratory_hours = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        Category_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.Category_Id)
                .Index(t => t.Category_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Retakes", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Exams", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Category_Id", "dbo.Categories");
            DropForeignKey("dbo.Retakes", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Retakes", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Faculty_Id", "dbo.Faculties");
            DropForeignKey("dbo.Exams", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "EducationForm_Id", "dbo.EducationForms");
            DropForeignKey("dbo.Exams", "ExamType_Id", "dbo.ExamTypes");
            DropForeignKey("dbo.Exams", "ExamForm_Id", "dbo.ExamForms");
            DropIndex("dbo.Teachers", new[] { "Category_Id" });
            DropIndex("dbo.Retakes", new[] { "Teacher_Id" });
            DropIndex("dbo.Retakes", new[] { "Subject_Id" });
            DropIndex("dbo.Retakes", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "Faculty_Id" });
            DropIndex("dbo.Students", new[] { "EducationForm_Id" });
            DropIndex("dbo.Exams", new[] { "Teacher_Id" });
            DropIndex("dbo.Exams", new[] { "Subject_Id" });
            DropIndex("dbo.Exams", new[] { "Student_Id" });
            DropIndex("dbo.Exams", new[] { "ExamType_Id" });
            DropIndex("dbo.Exams", new[] { "ExamForm_Id" });
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Retakes");
            DropTable("dbo.Faculties");
            DropTable("dbo.Students");
            DropTable("dbo.ExamTypes");
            DropTable("dbo.Exams");
            DropTable("dbo.ExamForms");
            DropTable("dbo.EducationForms");
            DropTable("dbo.Categories");
        }
    }
}
