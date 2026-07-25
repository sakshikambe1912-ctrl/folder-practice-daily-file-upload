using _21july_department.Models;
using Microsoft.AspNetCore.Mvc;

namespace _21july_department.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department/Details?deptName=IT
        public ActionResult Details(string deptName)
        {
            var departments = DepartmentData.GetAll();

            var selected = departments.Where(d => d.DepartmentName == deptName).ToList();

            ViewBag.SuccessMessage = TempData["SuccessMessage"];
            ViewBag.EmployeeName = TempData["EmployeeName"];
            ViewBag.EmployeeDepartment = TempData["EmployeeDepartment"];

            return View(selected.Any() ? selected : departments);
        }
    }
}
