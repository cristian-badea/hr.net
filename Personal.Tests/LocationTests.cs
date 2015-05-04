using Personal.Entities;
using Personal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;

namespace Personal.Tests
{
    class LocationTests
    {
        public void CanAddLocation()
        {
            using(var context = new HrDbContext())
            {

                var location = new Location
                {
                    StreetAddress = "Nicolae Titulescu",
                    PostalCode = "11141",
                    City = "Bucuresti",
                    StateProvince = "Bucuresti"
                };

                context.Locations.Add(location);
                context.SaveChanges();

                //get
                var retrievedLocation = context.Locations.Single(j => j.LocationId == location.LocationId);

                //verificare
                retrievedLocation.ShouldBe(location);
            }
        }

        public void QuerableVsEnumerable()
        {
            using (var context = new HrDbContext())
            {
                var locations = context.Locations.Where(x => x.City.StartsWith("O"));
                var locationList = locations.ToList();

            };

        }
    }
}
