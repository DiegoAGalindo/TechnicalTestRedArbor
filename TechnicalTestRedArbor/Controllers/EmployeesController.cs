using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTestRedArbor.Models;
using TechnicalTestRedArbor.Repositories;

namespace TechnicalTestRedArbor.Controllers
{
    [Route("api/redarbor")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeesController(EmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeRepository.DeleteById(id);

            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _employeeRepository.GetAll();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var responseEmployee = await _employeeRepository.GetById(id);
            return Ok(responseEmployee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RequestEmployee requestEmployee)
        {
            if (ModelState == null || !ModelState.IsValid) return BadRequest(ModelState);
            var id = await _employeeRepository.Insert(requestEmployee);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RequestEmployee requestEmployee)
        {
            if (ModelState == null || !ModelState.IsValid) return BadRequest(ModelState);
            await _employeeRepository.Update(requestEmployee, id);
            return Ok();
        }
    }
}