using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System.ComponentModel.DataAnnotations;

namespace EmployeePortal.Models
{
    public class Employee
    {
        [Key]
        public int ID { get; set; }
        public  string? Name { get; set; }
        public string? Email { get; set; } 
        public string? Mobile { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public bool Status { get; set; }
    }
}
