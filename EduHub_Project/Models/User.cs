using System.ComponentModel.DataAnnotations;

namespace EduHub_Project.Models
{//This class stores the user role (admin or the customer) and all user information.
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? UserName { get; set; }
        public string? MobileNumber { get; set; }
        public string?   UserRole { get; set; }
        public string? ProfileImage { get; set;}

    }
}