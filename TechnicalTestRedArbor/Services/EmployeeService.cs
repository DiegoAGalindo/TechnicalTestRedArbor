using System.Collections.Generic;
using System.Threading.Tasks;
using TechnicalTestRedArbor.Models;
using TechnicalTestRedArbor.Repositories;

namespace TechnicalTestRedArbor.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository _employeeRepository;

        public EmployeeService(EmployeeRepository employeeRepository) => _employeeRepository = employeeRepository;

        public async Task Delete(int id)
        {
            await _employeeRepository.DeleteById(id);
        }

        public async Task<List<ResponseEmployee>> Get()
        {
            return await _employeeRepository.GetAll();
        }

        public async Task<ResponseEmployee> GetById(int id)
        {
            return await _employeeRepository.GetById(id);
        }

        public async Task<int> Insert(RequestEmployee requestEmployee)
        {
            return await _employeeRepository.Insert(requestEmployee);
        }

        public async Task Update(RequestEmployee requestEmployee, int id)
        {
            await _employeeRepository.Update(requestEmployee, id);
        }
    }
}