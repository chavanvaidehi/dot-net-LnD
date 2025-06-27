using Microsoft.AspNetCore.Mvc;

namespace ShoppingSite.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("UserName") == null)
                return RedirectToAction("Login", "Account");

            ViewBag.User = HttpContext.Session.GetString("UserName");
            return View();
        }

        public IActionResult About() => View();

        public IActionResult Contact() => View();
    }
}
