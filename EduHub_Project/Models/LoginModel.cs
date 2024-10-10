using System.ComponentModel.DataAnnotations;

namespace EduHub_Project.Models
{
    public class LoginModel
    {
        [Required]
        
        public string? Email { get; set; }

        [Required]
        [MinLength(8)]
        public string? Password { get; set; }
    }
}
