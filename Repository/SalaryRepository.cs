using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repository
{
    public class SalaryRepository : ISalaryRepository
    {
        private readonly AppDbContext _context;
        public SalaryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Salary>> GetAllAsync()
        {
            return await _context.Salaries.Include(s => s.Employee).ToListAsync();
        }
        public async Task<Salary> GetByIdAsync(int id)
        {
            return await _context.Salaries.Include(s => s.Employee)
                                          .FirstOrDefaultAsync(s => s.Id == id);
        }
        public async Task<Salary> AddAsync(Salary salary)
        {
            _context.Salaries.Add(salary);
            await _context.SaveChangesAsync();
            return salary;
        }
        public async Task<Salary> UpdateAsync(Salary salary)
        {
            _context.Salaries.Update(salary);
            await _context.SaveChangesAsync();
            return salary;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null) return false;

            _context.Salaries.Remove(salary);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> CalculateTotalPayAsync(int id)
        {
            var salary = await _context.Salaries.FindAsync(id);
            if (salary == null) return 0;

            return salary.Basic + salary.HRA + salary.Bonus - salary.Deductions;
        }
    }
}
