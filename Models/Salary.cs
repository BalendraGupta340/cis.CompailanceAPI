namespace EmployeePortal.Models
{
    public class Salary
    {
        public int Id { get; set; }
        public int EmployeeId { get; set; }
        public decimal Basic { get; set; }
        public decimal HRA { get; set; }
        public decimal Bonus { get; set; }
        public decimal Deductions { get; set; }
        public DateTime SalaryMonth { get; set; }

        // Navigation property
        public Employee Employee { get; set; }

        // Method to calculate total pay (Basic + HRA + Bonus - Deductions)
        public decimal GetTotalPay()
        {
            return Basic + HRA + Bonus - Deductions;
        }
    }
}
