using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Repository
{
    public class EmployeeRepository
    {
        private readonly AppDbContext Db;
        public EmployeeRepository(AppDbContext dbcontext)
        { 
            this.Db = dbcontext;

        }
        public async Task<List<Employee>> GetAllEmployee()
        { 
            return await Db.Employees.ToListAsync();
        }
        public async Task SaveEmployee(Employee emp)
        { 
           await Db.Employees.AddAsync(emp);
            await Db.SaveChangesAsync();
        }
        public async Task UpdateEmployee(int id, Employee obj)
        { 
            var EmpUpdate=await Db.Employees.FindAsync(id);
            if (EmpUpdate == null)
            {
                throw new Exception("Employee Not Found");
            }
            EmpUpdate.Name = obj.Name;
            EmpUpdate.Email=obj.Email;
            EmpUpdate.Mobile=obj.Mobile;
            EmpUpdate.Age = obj.Age;
            EmpUpdate.Salary=obj.Salary;
            EmpUpdate.Status=obj.Status;

            await Db.SaveChangesAsync();
        }
        public async Task DeleteEmployee(int id)
        {
            var EmpDelete = await Db.Employees.FindAsync(id);
            if (EmpDelete==null)
            {
                throw new Exception("Employee Not Found");
            }
            Db.Employees.Remove(EmpDelete);
          await  Db.SaveChangesAsync() ;
        }
    }
}
