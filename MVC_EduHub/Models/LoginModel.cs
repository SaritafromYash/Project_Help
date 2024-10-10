using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub.Models
{
    public class LoginModel
    {
        [Key]
        [Required]
        public string? Username { get; set; }

        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
