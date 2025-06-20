using Microsoft.AspNetCore.Mvc;
using InventoryManagementApp.Models;
using Microsoft.AspNetCore.Http;

namespace InventoryManagementApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User model)
        {
            if (!ModelState.IsValid)
                return View(model);

            
            if (model.Username == "admin" && model.Password == "1234")
            {
                HttpContext.Session.SetString("Username", model.Username);
                return RedirectToAction("Index", "Product");
            }

            ViewBag.Error = "Invalid credentials!";
            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
