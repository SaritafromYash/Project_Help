
using MVC_EduHub.Models;

namespace MVC_EduHub.services
{
    public interface IUserService
    {
      
       
        User CreateUser(User newUser);
      
        User GetEducator(string username, string password);
        User GetStudent(string username,string password);
    }
}
