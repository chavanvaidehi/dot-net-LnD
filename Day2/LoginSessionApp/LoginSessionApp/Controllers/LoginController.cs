using LoginSessionApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LoginSessionApp.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(LoginViewModel model, bool RememberMe)
        {
            if (ModelState.IsValid)
            {
                if (model.Email == "admin@example.com" && model.Password == "12345")
                {
                    HttpContext.Session.SetString("user", model.Email);

                    CookieOptions option = new CookieOptions();
                    option.Expires = RememberMe ? DateTime.Now.AddDays(1) : DateTime.Now.AddMinutes(20);

                    Response.Cookies.Append("user_email", model.Email, option);

                    return RedirectToAction("Dashboard", "Home");
                }
                else
                {
                    ViewBag.Error = "Invalid email or password!";
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            Response.Cookies.Delete("user_email");
            return RedirectToAction("Index");
        }
    }
}
