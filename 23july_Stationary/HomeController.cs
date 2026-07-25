using _23july_Stationary.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;

namespace _23july_Stationary.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Login login)
        {
            if(login.Username=="admin" && login.Password == "123456")
            {
                HttpContext.Session.SetString("User", login.Username);
                return RedirectToAction("Dashboard");
            } ViewBag.Error = "Invalid Username or Password";
            return View(login);
        }

        public ActionResult Dashboard()
        {
            var user = HttpContext.Session.GetString("User");
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index");
            }
            ViewBag.User = user;

            List<Stationary> stationaries = new List<Stationary>()
            {
                new Stationary { Id = 3, Name = "NoteBook", Stock = 6 },
                new Stationary { Id=8,Name="Physics Book",Stock=3 },
                new Stationary { Id=5,Name="pen",Stock=6 },
                new Stationary { Id=10,Name="Sticky Notes",Stock=9 }
            };
            return View(stationaries);
        }

        public ActionResult Logout() { 
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
