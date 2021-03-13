namespace InspectionBoardLibrary.UserContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class UserContextConfig : DbMigrationsConfiguration<InspectionBoardLibrary.Database.ExamContext>
    {
        public UserContextConfig()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"UserContextMigrations";
        }

        protected override void Seed(InspectionBoardLibrary.Database.ExamContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
