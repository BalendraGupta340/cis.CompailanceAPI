using EmployeePortal.Models;

namespace EmployeePortal.Repository
{
    public interface ISalaryRepository
    {
        Task<IEnumerable<Salary>> GetAllAsync();
        Task<Salary> GetByIdAsync(int id);
        Task<Salary> AddAsync(Salary salary);
        Task<Salary> UpdateAsync(Salary salary);
        Task<bool> DeleteAsync(int id);
        Task<decimal> CalculateTotalPayAsync(int id); // Basic + HRA + Bonus - Deductions
    }
}
