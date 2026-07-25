using _22july_Automobile.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using System.Diagnostics;

namespace _22july_Automobile.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Automobile automobile)
        {
            if (ModelState.IsValid)
            {   
                

                return Content($"You are Registerd Sucessefully , Automobile Name:{automobile.Name} , Brand:{automobile.Brand}");
            }return View(automobile);
        }
    }
}
