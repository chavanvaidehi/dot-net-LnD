using Microsoft.AspNetCore.Mvc;
using RefactoredLoginApp.Models;
using RefactoredLoginApp.Repositories;

namespace RefactoredLoginApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserRepository _userRepository;

        
        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            if (ModelState.IsValid)
            {
                var validUser = await _userRepository.ValidateUserAsync(user.Username, user.Password);
                if (validUser != null)
                {
                    
                    HttpContext.Session.SetInt32("UserId", validUser.Id);
                    return RedirectToAction("Index", "Home"); 
                }

                ModelState.AddModelError(string.Empty, "Invalid username or password.");
            }

            return View(user);
        }

        
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}
