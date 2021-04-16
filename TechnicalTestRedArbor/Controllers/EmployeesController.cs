using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TechnicalTestRedArbor.Models;
using TechnicalTestRedArbor.Repositories;
using TechnicalTestRedArbor.Services;

namespace TechnicalTestRedArbor.Controllers
{
    [Route("api/redarbor")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeRepository employeeRepository)
        {
            _employeeService = new EmployeeService(employeeRepository);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _employeeService.Delete(id);
            return Ok();
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var list = await _employeeService.Get();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var responseEmployee = await _employeeService.GetById(id);
            return Ok(responseEmployee);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] RequestEmployee requestEmployee)
        {
            var id = await _employeeService.Insert(requestEmployee);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] RequestEmployee requestEmployee)
        {
            await _employeeService.Update(requestEmployee, id);
            return Ok();
        }
    }
}