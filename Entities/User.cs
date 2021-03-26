using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectsApi.Entities
{
    public class User
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Team { get; set; }

        [Required]
        public DateTime JoinedAt { get; set; }

        [Required]
        public byte[] PasswordHash { get; set; }

        [Required]
        public byte[] PasswordSalt { get; set; }
    }
}
