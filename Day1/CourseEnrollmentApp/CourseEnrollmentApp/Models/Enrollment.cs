using System.ComponentModel.DataAnnotations;

namespace CourseEnrollmentApp.Models
{
    public class Enrollment
    {
        public int CourseId { get; set; }       // ID of selected course
        public string CourseTitle { get; set; } // Title of selected course

        [Required(ErrorMessage = "Student name is required.")]
        public string StudentName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        public string UserRole { get; set; }    // Passed via Hidden field
    }
}
