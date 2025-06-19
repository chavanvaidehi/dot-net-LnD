using Microsoft.AspNetCore.Mvc;
using CourseEnrollmentApp.Models;

namespace CourseEnrollmentApp.Controllers
{
    public class CourseController : Controller
    {
        // Static list of courses (in-memory)
        private static List<Course> courses = new()
        {
            new Course { Id = 1, Title = "ASP.NET Core MVC" },
            new Course { Id = 2, Title = "Entity Framework Core" }
        };

        // STEP 1: Show list of courses
        public IActionResult Index()
        {
            return View(courses); // Send course list to Index.cshtml view
        }

        // STEP 2: Show form for selected course
        [HttpGet("Course/Enroll/{id}")]
        public IActionResult Enroll(int id)
        {
            var selectedCourse = courses.FirstOrDefault(c => c.Id == id);
            if (selectedCourse == null)
                return NotFound(); // Course doesn't exist

            var model = new Enrollment
            {
                CourseId = selectedCourse.Id,
                CourseTitle = selectedCourse.Title,
                UserRole = "guest" // Hidden field value
            };

            return View(model); // Send data to Enroll.cshtml view
        }

        // STEP 3: Handle form submission
        [HttpPost]
        public IActionResult Enroll(Enrollment model)
        {
            if (ModelState.IsValid)
            {
                // Pass values to confirmation using query string
                return RedirectToAction("Confirmation", new
                {
                    name = model.StudentName,
                    course = model.CourseTitle,
                    role = model.UserRole
                });
            }

            return View(model); // Show errors if invalid
        }

        // STEP 4: Show confirmation page
        public IActionResult Confirmation(string name, string course, string role)
        {
            ViewBag.Name = name;
            ViewBag.Course = course;
            ViewBag.Role = role;
            return View();
        }
    }
}
