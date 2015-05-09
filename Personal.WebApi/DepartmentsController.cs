using Personal.Entities;
using Personal.Persistence;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Personal.WebApi
{
    public class DepartmentsController : ApiController
    {
        private readonly IHrContext context;

        public DepartmentsController(IHrContext ctx)
        {
            context = ctx;
        }

        //GET api/<controller>
        public IEnumerable<Department> Get()
        {
            return context.Departments;
        }

        //GET api/<controller>/id
        public Department Get(int id)
        {
            try
            {
                return context.Departments.Find(id);
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }

        //POST api/<controller>
        public int Post(Department department)
        {
            context.Departments.Add(department);
            return context.SaveChanges();
        }

        //PUT api/<controller>/id
        public Department Put(int id, Department department)
        {
            var departmentDb = context.Departments.Find(id);
            if (departmentDb != null)
            {
                departmentDb.DepartmentName = department.DepartmentName;
                departmentDb.Location = department.Location;
                departmentDb.LocationId = department.Location.LocationId;
            }
            context.SaveChanges();
            return department;
        }

        //DELETE api/<controller>/id
        public void Delete(int id)
        {
            var department = context.Departments.Find(id);
            context.Departments.Remove(department);
            context.SaveChanges();
        }
    }
}