using Microsoft.AspNetCore.Mvc;

namespace EmployeeMvc.Controllers
{
    public class EmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
