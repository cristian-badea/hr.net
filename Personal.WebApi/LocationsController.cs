using Personal.Entities;
using Personal.Persistence;
using System.Collections.Generic;
using System.Web.Http;

namespace Personal.WebApi
{
    public class LocationsController : ApiController
    {
        private readonly IHrContext context;

        public LocationsController(IHrContext ctx)
        {
            context = ctx;
        }

        //GET api/<controller>
        public IEnumerable<Location> Get()
        {
            return context.Locations;
        }

        //GET api/<controller>/id
        public Location Get(int id)
        {
            return context.Locations.Find(id);
        }

        //POST api/<controller>
        public int Post(Location Location)
        {
            context.Locations.Add(Location);
            return context.SaveChanges();
        }

        //PUT api/<controller>/id
        public Location Put(int id, Location Location)
        {
            var LocationDb = context.Locations.Find(id);
            if (LocationDb != null)
            {
                LocationDb.City = Location.City;
                LocationDb.PostalCode = Location.PostalCode;
                LocationDb.StateProvince = Location.StateProvince;
                LocationDb.StreetAddress = Location.StreetAddress;
            }
            context.SaveChanges();
            return Location;
        }

        //DELETE api/<controller>/id
        public void Delete(int id)
        {
            var Location = context.Locations.Find(id);
            context.Locations.Remove(Location);
            context.SaveChanges();
        }
    }
}