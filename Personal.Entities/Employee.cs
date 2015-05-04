﻿using System;

namespace Personal.Entities
{
    public class Employee
    {
        //configurati controlere, teste la toate, migrari ,adaugati la context , faceti contexte care il folosesc,  . 1 saptamana
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime HireDate { get; set; }
        public Job Job { get; set; }
        public decimal Salary { get; set; }
        public decimal CommisionPercent { get; set; }
        public Employee Manager { get; set; }
        public Department Department { get; set; }
    }
}
