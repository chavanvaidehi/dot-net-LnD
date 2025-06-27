using System.ComponentModel.DataAnnotations;

namespace RefactoredLoginApp.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
