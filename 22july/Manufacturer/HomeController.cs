using _22july_Manufacturing.Models;
using AutomobileApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Net.Mail;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace _22july_Manufacturing.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/Index
        // Shows the registration form. Manufacturer details are only shown
        // in the view after a successful POST (see RegistrationSuccess flag).
        [HttpGet]
        public IActionResult Index()
        {
            var model = new Automobile { Manufacturer = new Manufacturer() };

            if (TempData["RegistrationSuccess"] is bool success && success)
            {
                ViewBag.RegistrationSuccess = true;
                var manufacturerJson = TempData["ManufacturerDetails"] as string;
                if (!string.IsNullOrEmpty(manufacturerJson))
                {
                    ViewBag.RegisteredManufacturer = JsonSerializer.Deserialize<Manufacturer>(manufacturerJson);
                }
            }
            else
            {
                ViewBag.RegistrationSuccess = false;
            }

            return View(model);
        }

        // POST: /Home/Index
        // Accepts Automobile + Manufacturer details together through Model Binding.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Automobile automobile)
        {
            // ModelState automatically validates Data Annotations
            // on both Automobile and the nested Manufacturer object.
            if (!ModelState.IsValid)
            {
                ViewBag.RegistrationSuccess = false;
                return View(automobile);
            }

            // --- Simulate saving the automobile registration ---
            // In a real app, this is where you'd call a DbContext.Add() + SaveChanges().
            bool registrationSaved = TryRegisterAutomobile(automobile);

            if (!registrationSaved)
            {
                ModelState.AddModelError(string.Empty, "Automobile registration failed. Please try again.");
                ViewBag.RegistrationSuccess = false;
                return View(automobile);
            }

            // Registration succeeded -> stash manufacturer details to show after redirect
            TempData["ManufacturerDetails"] = JsonSerializer.Serialize(automobile.Manufacturer);
            TempData["RegistrationSuccess"] = true;

            return RedirectToAction("Index");
        }

        private bool TryRegisterAutomobile(Automobile automobile)
        {
            // Placeholder for actual persistence logic (e.g., EF Core SaveChanges).
            // Returns true to indicate the automobile was registered successfully.
            return automobile != null;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
