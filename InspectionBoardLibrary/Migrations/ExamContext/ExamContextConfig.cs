namespace InspectionBoardLibrary.Migrations.ExamContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class ExamContextConfig : DbMigrationsConfiguration<InspectionBoardLibrary.Database.Contexts.ExamContext>
    {
        public ExamContextConfig()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(InspectionBoardLibrary.Database.Contexts.ExamContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
