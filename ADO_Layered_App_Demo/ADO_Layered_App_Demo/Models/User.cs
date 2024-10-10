using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Layered_App_Demo.Models
{
    internal class User
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Mobilenumber { get; set; }
        public string? UserRole { get; set; }
        public string? ProfileImage { get; set; }
    }
}
