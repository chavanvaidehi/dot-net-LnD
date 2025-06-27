using Microsoft.AspNetCore.Mvc;

namespace SecureLoginApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("User") == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            ViewBag.User = HttpContext.Session.GetString("User");
            return View();
        }
    }
}
