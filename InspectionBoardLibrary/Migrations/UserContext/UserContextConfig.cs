namespace InspectionBoardLibrary.Migrations.UserContext
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class UserContextConfig : DbMigrationsConfiguration<InspectionBoardLibrary.Database.Contexts.UserContext>
    {
        public UserContextConfig()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(InspectionBoardLibrary.Database.Contexts.UserContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
