using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class AuthenticateModel
    {
        // [Key]
        // public int Id { get; set; }  // must be public!
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        // public Role Role { get; set; }
    }
}