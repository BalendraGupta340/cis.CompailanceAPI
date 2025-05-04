using EmployeePortal.Models;
using EmployeePortal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalaryController : ControllerBase
    {
        private readonly ISalaryRepository _salaryRepository;
        public SalaryController(ISalaryRepository salaryRepository)
        {
            _salaryRepository = salaryRepository;
        }
        // GET: api/salary
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Salary>>> GetAllSalaries()
        {
            var salaries = await _salaryRepository.GetAllAsync();
            return Ok(salaries);
        }
        // GET: api/salary/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Salary>> GetSalaryById(int id)
        {
            var salary = await _salaryRepository.GetByIdAsync(id);
            if (salary == null)
                return NotFound();

            return Ok(salary);
        }

        // POST: api/salary
        [HttpPost]
        public async Task<ActionResult<Salary>> AddSalary([FromBody] Salary salary)
        {
            var created = await _salaryRepository.AddAsync(salary);
            return CreatedAtAction(nameof(GetSalaryById), new { id = created.Id }, created);
        }

        // PUT: api/salary/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<Salary>> UpdateSalary(int id, [FromBody] Salary salary)
        {
            if (id != salary.Id)
                return BadRequest();

            var updated = await _salaryRepository.UpdateAsync(salary);
            return Ok(updated);
        }

        // DELETE: api/salary/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSalary(int id)
        {
            var success = await _salaryRepository.DeleteAsync(id);
            if (!success)
                return NotFound();

            return NoContent();
        }

        // GET: api/salary/calculate/{id}
        [HttpGet("calculate/{id}")]
        public async Task<ActionResult<decimal>> CalculateTotalPay(int id)
        {
            var total = await _salaryRepository.CalculateTotalPayAsync(id);
            return Ok(total);
        }
    }
}

