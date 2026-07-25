using _21julyemployee.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _21julyemployee.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(Employee employee)
        {
            if (ModelState.IsValid)
            {
                return Content("Employee Registerd Sucessfully,"+$"Employee Name:{employee.employee_name}," + $"Employee Department:{employee.department}");
            }
            return View(employee);
        }
    }
}
