using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public  string? Name { get; set; }
        [EmailAddress]
        public string? Email { get; set; } 
        public string? Mobile { get; set; }
        public int Age { get; set; }
        public int CurrentSalaryAmount { get; set; }
        public bool Status { get; set; }
        // Navigation property
        public ICollection<Salary> Salaries { get; set; }
    }
}
