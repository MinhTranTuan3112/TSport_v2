using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TSport.Api.DataAccess.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public required string Email { get; set; }

        [Required]
        public required string Password { get; set; }
    }
}