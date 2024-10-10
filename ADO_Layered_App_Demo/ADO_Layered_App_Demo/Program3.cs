using ADO_Layered_App_Demo.Models;
using ADO_Layered_App_Demo.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Layered_App_Demo
{
    internal class Program3
    {
        public static void Main()
        {
            UserRepository userRepository = new UserRepository();
            Console.WriteLine("Login Page");
            Console.WriteLine("Enter username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter password");
            string password = Console.ReadLine();
            User user = userRepository.Login(username,password);
            if (user != null) {
                Console.WriteLine($"User exist\n{user.Username}-{user.Password}-{user.Email}-{user.UserRole}-{user.Mobilenumber}");
            }
            else Console.WriteLine("User does not exist");

        }
    }
}
