using Microsoft.EntityFrameworkCore;
using MVC_EduHub.Models;
using MVC_EduHub.services;

namespace EduHub_Project.repository
{
    public class UserRepository : IUserService
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context)
        {
            _context = context;
        }

      
       

        public User CreateUser(User newUser)
        {
            _context.Users.Add(newUser);
             _context.SaveChanges();
            return newUser;
        }
            

        
        public User GetEducator(string username, string password)
        {//select Uisername,Userole, Email .... from users where username=username and password =password and userRole = "Educator"

            var data = _context.Users.FirstOrDefault(x=>x.UserName == username && x.Password == password && x.UserRole== "Educator");
            return data;
        }

        public User GetStudent(string username, string password )
        {
            var data=_context.Users.FirstOrDefault(x=>x.UserName==username && x.Password==password && x.UserRole =="student" );

            return data;
        }
    }
}