using Microsoft.AspNetCore.Mvc;
using ShoppingSite.Data;
using ShoppingSite.Models;
using System.Security.Cryptography;
using System.Text;

namespace ShoppingSite.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                if (_context.Users.Any(u => u.Email == user.Email))
                {
                    ModelState.AddModelError("Email", "Email already registered");
                    return View();
                }

                user.Password = HashPassword(user.Password);

                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult Login() => View();

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            string hashed = HashPassword(password);
            var user = _context.Users.FirstOrDefault(u => u.Email == email && u.Password == hashed);
            if (user == null)
            {
                ViewBag.Error = "Invalid credentials";
                return View();
            }

            HttpContext.Session.SetInt32("UserId", user.Id);
            HttpContext.Session.SetString("UserName", user.Name);
            return RedirectToAction("Index", "Product");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                ViewBag.Error = "Email not found.";
                return View();
            }

            TempData["ResetEmail"] = email;
            return RedirectToAction("ResetPassword");
        }

        public IActionResult ResetPassword()
        {
            if (TempData["ResetEmail"] == null)
                return RedirectToAction("Login");

            ViewBag.Email = TempData["ResetEmail"];
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string email, string newPassword)
        {
            var user = _context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            user.Password = HashPassword(newPassword);
            _context.SaveChanges();

            TempData["Success"] = "Password updated successfully. Please login.";
            return RedirectToAction("Login");
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
