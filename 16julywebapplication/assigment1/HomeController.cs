using _16thjulyassigment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _16thjulyassigment1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Employee> employees = new List<Employee>()
            { new Employee{EmployeeId=101,Name="Pooja",Depratment="Information technology", Salary=15000,Email="Pooja123@gamil.com"},
              new Employee{EmployeeId=102,Name="Priya",Depratment="Computer Science and Engineering", Salary=35000,Email="priya23@gamil.com"},
              new Employee{EmployeeId=103,Name="Priyanka",Depratment="Electrical", Salary=25000,Email="Priyanka@gamil.com"},
              new Employee{EmployeeId=104,Name="Pihu",Depratment="Mechanical", Salary=35000,Email="Pihu3@gamil.com"},
              new Employee{EmployeeId=105,Name="Pranjali",Depratment="civil", Salary=65000,Email="Pranjal23@gamil.com"},

            };
            return View(employees);
        }

        
    }
}
