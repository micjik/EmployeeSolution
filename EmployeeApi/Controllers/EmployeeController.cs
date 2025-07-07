using EmployeeApi.Dtos;
using EmployeeApi.Service;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IServiceEmployee _serviceEmployee;
        public EmployeeController(IServiceEmployee serviceEmployee)
        {
            _serviceEmployee = serviceEmployee;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            List<EmployeeGetDtos> employees = await _serviceEmployee.GetEmployeesAsync();
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employeeGetDtos = await _serviceEmployee.GetEmployeeById(id);
            return Ok(employeeGetDtos);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] EmployeeCreateDtos employeeCreateDtos)
        {
            string result = await _serviceEmployee.CreateEmployee(employeeCreateDtos);
            return Ok(result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, EmployeeCreateDtos employee)
        {
            var updated = await _serviceEmployee.UpdateAsync(id, employee);
            return Ok(updated);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _serviceEmployee.DeleteEmployeeAsync(id);
            return Ok(deleted);
        }

    }
}
