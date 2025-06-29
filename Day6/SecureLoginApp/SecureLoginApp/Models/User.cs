﻿using System.ComponentModel.DataAnnotations;

namespace SecureLoginApp.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }  

        [Required]
        public string? Password { get; set; } 
    }
}
