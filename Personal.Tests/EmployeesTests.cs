using Personal.Entities;
using Personal.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shouldly;
using System.Data.Entity.Validation;


namespace Personal.Tests
{
    class EmployeesTests
    {
        public void CanAddEmployee()
        {
            var context = new HrDbContext();

            var employee = new Employee
            {
                FirstName = "Cristi",
                LastName = "Badea",
                Email = "cristi@ceva",
                HireDate = DateTime.Now,
                Salary = 100,
                CommisionPercent = 2,
                DepartmentId = 2,
                JobId = "DEV",
            };

            context.Employees.Add(employee);

            context.SaveChanges();

            var retrievedEmployee = context.Employees.Single(empl => empl.EmployeeId == employee.EmployeeId);

            retrievedEmployee.ShouldBe(employee);
        }

    }
}
