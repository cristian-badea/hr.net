namespace Personal.Persistence.Migrations
{
    using Personal.Entities;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Personal.Persistence.HrDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Personal.Persistence.HrDbContext";
        }

        protected override void Seed(Personal.Persistence.HrDbContext context)
        {

            var locationList = new List<Location>()
            {
                new Location(){
                    City = "Arad",
                    StreetAddress = "12340",
                    StateProvince = "1111",
                    PostalCode = "1111"
                }, new Location(){
                    City = "Oradea",
                    StreetAddress = "1234",
                    StateProvince = "2222",
                    PostalCode = "2222"
                 }, new Location(){
                    City = "Maramures",
                    StreetAddress = "1234",
                    StateProvince = "2222",
                    PostalCode = "2222"
                 }
          
            };

            foreach (var l in locationList)
            {
                context.Locations.AddOrUpdate(l);
            };
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
