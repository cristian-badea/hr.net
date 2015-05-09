using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Personal.Entities
{
    [Table("Employee",Schema = "HR")]
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        [Required]
        public string JobId { get; set; }

        [ForeignKey("JobId")]
        public Job Job { get; set; }

        [Required]
        public decimal Salary { get; set; }

        public decimal? CommisionPercent { get; set; }

        public int? ManagerId { get; set; }

        [ForeignKey("ManagerId")]
        public Employee Manager { get; set; }

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department Department { get; set; }
    }
}
