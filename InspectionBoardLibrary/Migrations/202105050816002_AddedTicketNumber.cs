namespace InspectionBoardLibrary.Migrations.ExamContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTicketNumber : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exams", "Ticket_Id", c => c.Int());
            AddColumn("dbo.Tickets", "Number", c => c.Int(nullable: false));
            AlterColumn("dbo.Exams", "Date", c => c.DateTime());
            CreateIndex("dbo.Exams", "Ticket_Id");
            AddForeignKey("dbo.Exams", "Ticket_Id", "dbo.Tickets", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Exams", "Ticket_Id", "dbo.Tickets");
            DropIndex("dbo.Exams", new[] { "Ticket_Id" });
            AlterColumn("dbo.Exams", "Date", c => c.DateTime(precision: 7, storeType: "datetime2"));
            DropColumn("dbo.Tickets", "Number");
            DropColumn("dbo.Exams", "Ticket_Id");
        }
    }
}
