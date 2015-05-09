using Personal.Entities;
using Personal.Persistence;
using System.Collections.Generic;
using System.Web.Http;

namespace Personal.WebApi
{
    public class EmployeesController : ApiController
    {
        private readonly IHrContext context;

        public EmployeesController(IHrContext ctx)
        {
            context = ctx;
        }

        //GET api/<controller>
        public IEnumerable<Employee> Get()
        {
            return context.Employees;
        }

        //GET api/<controller>/id
        public Employee Get(int id)
        {
            return context.Employees.Find(id);
        }

        //POST api/<controller>
        public int Post(Employee Employee)
        {
            context.Employees.Add(Employee);
            return context.SaveChanges();
        }

        //PUT api/<controller>/id
        public Employee Put(int id, Employee Employee)
        {
            var EmployeeDb = context.Employees.Find(id);
            if (EmployeeDb != null)
            {
                EmployeeDb.CommisionPercent = Employee.CommisionPercent;
                EmployeeDb.Department = Employee.Department;
                EmployeeDb.DepartmentId = Employee.DepartmentId;
                EmployeeDb.Email = Employee.Email;
                EmployeeDb.FirstName = Employee.FirstName;
                EmployeeDb.HireDate = Employee.HireDate;
                EmployeeDb.Job = Employee.Job;
                EmployeeDb.JobId = Employee.JobId;
                EmployeeDb.LastName = Employee.LastName;
                EmployeeDb.Manager = Employee.Manager;
                EmployeeDb.ManagerId = Employee.ManagerId;
                EmployeeDb.PhoneNumber = Employee.PhoneNumber;
                EmployeeDb.Salary = Employee.Salary;
            }
            context.SaveChanges();
            return Employee;
        }

        //DELETE api/<controller>/id
        public void Delete(int id)
        {
            var Employee = context.Employees.Find(id);
            context.Employees.Remove(Employee);
            context.SaveChanges();
        }
    }
}
