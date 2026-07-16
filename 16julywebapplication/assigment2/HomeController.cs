using _16thjulyassigment2.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _16thjulyassigment2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            List<Department> departmentList = new List<Department>()
            {
                 new Department{DepartmentName="information technology",DepartmentHead="tony",HeadContact=9234657810,HeadEmail="tony123@gmail.com"},
                new Department{DepartmentName="policy",DepartmentHead="hulk",HeadContact=9234265781,HeadEmail="hulk3@gmail.com"},
                 new Department{DepartmentName="Insurance",DepartmentHead="gaurao",HeadContact=7234657810,HeadEmail="gaurao23@gmail.com"},
                  new Department{DepartmentName="production",DepartmentHead="saurabh",HeadContact=9234654561,HeadEmail="saurabh@gmail.com"},
                   new Department{DepartmentName="sales",DepartmentHead="sakshi",HeadContact=9834657810,HeadEmail="sakshi3@gmail.com"},
                    new Department{DepartmentName="development",DepartmentHead="pitter",HeadContact=6234657810,HeadEmail="pitter123@gmail.com"},
            };
            return View(departmentList);
        }

       
    }
}
