using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruStageController : ControllerBase
    {
        private readonly EmployeeRepository Emp;
        public TruStageController(EmployeeRepository EmpRepository)
        {
            this.Emp = EmpRepository;
        }
        [HttpGet]
        public async Task<ActionResult> EmployeeList()
        {
            var AllEmployee = await Emp.GetAllEmployee();
            return Ok(AllEmployee);
        }
    }
}
