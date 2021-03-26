using ProjectsApi.Validators;
using System.ComponentModel.DataAnnotations;

namespace ProjectsApi.Models
{
    public class AuthenticateModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 8)]
        [PasswordContent]
        public string Password { get; set; }
    }
}
