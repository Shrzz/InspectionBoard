namespace InspectionBoardLibrary.Migrations.ExamContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(precision: 7, storeType: "datetime2"),
                        ExamType = c.Byte(nullable: false),
                        ExamForm = c.Byte(nullable: false),
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
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Surname = c.String(),
                        Name = c.String(),
                        Patronymic = c.String(),
                        EducationForm = c.Byte(nullable: false),
                        Group_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.Group_Id)
                .Index(t => t.Group_Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Faculty = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LectoryHours = c.Int(nullable: false),
                        LaboratoryHours = c.Int(nullable: false),
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
                        Category = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Journals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Mark = c.Byte(nullable: false),
                        Student_Id = c.Int(),
                        Subject_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .Index(t => t.Student_Id)
                .Index(t => t.Subject_Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        Subject_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Subjects", t => t.Subject_Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.Subject_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Tickets", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Journals", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Journals", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Exams", "Teacher_Id", "dbo.Teachers");
            DropForeignKey("dbo.Exams", "Subject_Id", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Tickets", new[] { "User_Id" });
            DropIndex("dbo.Tickets", new[] { "Subject_Id" });
            DropIndex("dbo.Journals", new[] { "Subject_Id" });
            DropIndex("dbo.Journals", new[] { "Student_Id" });
            DropIndex("dbo.Students", new[] { "Group_Id" });
            DropIndex("dbo.Exams", new[] { "Teacher_Id" });
            DropIndex("dbo.Exams", new[] { "Subject_Id" });
            DropIndex("dbo.Exams", new[] { "Student_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Tickets");
            DropTable("dbo.Journals");
            DropTable("dbo.Teachers");
            DropTable("dbo.Subjects");
            DropTable("dbo.Groups");
            DropTable("dbo.Students");
            DropTable("dbo.Exams");
        }
    }
}
