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
    class DepartmentsTests
    {
        public void CanAddDepartment()
        {
            using(var context = new HrDbContext())
            {
                var location = new Location
                {
                    City = "Suceava",
                    PostalCode = "1114032",
                    StateProvince = "MM",
                    StreetAddress = "Stefan cel Mare"
                };

                var department = new Department
                {
                    DepartmentName = "Human Resources",
                    Location = location
                };

                context.Departments.Add(department);
                context.SaveChanges();

                //get
                var retrieveDepartment = context.Departments.Single(j => j.DepartmentId == department.DepartmentId);

                //verificare
                retrieveDepartment.ShouldBe(department);
            }
        }
        //lazy load
        public void LazyExample()
        {
            using (var ctx = new HrDbContext())
            {
                var depart = ctx.Departments;
                foreach(var d in depart)
                {
                    var l = d.Location;
                };
            }
        }

        //eager load
        public void IncludeExample()
        {
            using (var ctx = new HrDbContext())
            {
                var depart = ctx.Departments;
               
                var depWithLocation = depart.Include("Location").ToList();
            }
        }
    }
}
