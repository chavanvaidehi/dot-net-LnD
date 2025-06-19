using Microsoft.AspNetCore.Mvc;

namespace LoginSessionApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public IActionResult Dashboard()
        {
            
            string loginSource = "Session";

            
            var user = HttpContext.Session.GetString("user");

            
            if (string.IsNullOrEmpty(user))
            {
                var cookieEmail = HttpContext.Request.Cookies["user_email"];
                if (!string.IsNullOrEmpty(cookieEmail))
                {
                    HttpContext.Session.SetString("user", cookieEmail);
                    user = cookieEmail;
                    loginSource = "Cookie";
                }
            }

           
            if (string.IsNullOrEmpty(user))
            {
                return RedirectToAction("Index", "Login");
            }

            
            ViewBag.User = user;
            ViewBag.Source = loginSource;

            return View();
        }


    }
}
