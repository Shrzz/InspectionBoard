namespace InspectionBoardLibrary.Migrations.ExamContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Optimal : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Journal_Id", "dbo.Journals");
            DropForeignKey("dbo.Subjects", "Journal_Id", "dbo.Journals");
            DropIndex("dbo.Students", new[] { "Journal_Id" });
            DropIndex("dbo.Subjects", new[] { "Journal_Id" });
            DropColumn("dbo.Students", "Journal_Id");
            DropColumn("dbo.Subjects", "Journal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subjects", "Journal_Id", c => c.Int());
            AddColumn("dbo.Students", "Journal_Id", c => c.Int());
            CreateIndex("dbo.Subjects", "Journal_Id");
            CreateIndex("dbo.Students", "Journal_Id");
            AddForeignKey("dbo.Subjects", "Journal_Id", "dbo.Journals", "Id");
            AddForeignKey("dbo.Students", "Journal_Id", "dbo.Journals", "Id");
        }
    }
}
