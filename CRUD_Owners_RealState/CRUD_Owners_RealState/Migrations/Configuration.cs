namespace CRUD_Owners_RealState.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CRUD_Owners_RealState.Models.DbContextClass>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CRUD_Owners_RealState.Models.DbContextClass context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            //context.Database.ExecuteSqlCommand("UPDATE Owners SET OwnerType = 0 WHERE OwnerType = 'Buyer'");

            //// Set 'Invester' to 1
            //context.Database.ExecuteSqlCommand("UPDATE Owners SET OwnerType = 1 WHERE OwnerType = 'Invester'");

            //// Save changes to the database
            //context.SaveChanges();
        }
    }
}
