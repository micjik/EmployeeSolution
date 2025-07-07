using EmployeeMvc.Models;
using EmployeeMvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeMvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        public async Task<IActionResult> Index()
        {
            List<EmployeeGetDtos> employees = await _employeeService.GetAll();
            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateDtos employeeCreateDtos)
        {
            bool response = await _employeeService.CreateEmployee(employeeCreateDtos);
            return RedirectToAction("Index");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeAsync(int id)
        {
            bool deleted = await _employeeService.DeleteEmployeeAsync(id);
            return deleted ? NoContent() : NotFound();
        }
    }
}
