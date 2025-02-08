using EmployeePortal.Models;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeRepository Emp;
        public EmployeeController(EmployeeRepository EmpRepository)
        {
            this.Emp = EmpRepository;
        }
        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var AllEmployee = await Emp.GetAllEmployee();
            return Ok(AllEmployee);
        }
        [HttpPost]
        public async Task<ActionResult> AddEmployee(Employee vm)
        {
            await Emp.SaveEmployee(vm);
            return Ok(vm);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEmployee(int id, [FromBody] Employee vm)
        {
            await Emp.UpdateEmployee(id, vm);
            return Ok(vm);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteEmp(int id)
        { 
            await Emp.DeleteEmployee(id);
            return Ok();
        }
    }
}
