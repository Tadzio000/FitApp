using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
{
    public class AuthenticateModel : DbContext
    {
        [Key]
        public int Id { get; set; }  // must be public!
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }
    }
}