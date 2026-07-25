using _21july_department.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _21july_department.Controllers
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
                // Save employee here (DB call / list) if needed

                TempData["SuccessMessage"] = "Employee Added Successfully";
                TempData["EmployeeName"] = employee.Name;
                TempData["EmployeeDepartment"] = employee.Department;

                // Redirect to Department Details page after successful registration
                return RedirectToAction("Details", "Department", new { deptName = employee.Department });
            }

            // Validation failed — redisplay form with errors
            return View(employee);
        }
    }
}
