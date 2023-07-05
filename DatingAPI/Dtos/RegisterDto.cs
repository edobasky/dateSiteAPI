﻿using System.ComponentModel.DataAnnotations;

namespace DatingAPI.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string  UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
