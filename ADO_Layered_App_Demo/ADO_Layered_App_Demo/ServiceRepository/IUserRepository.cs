using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ADO_Layered_App_Demo.Models;

namespace ADO_Layered_App_Demo.ServiceRepository
{
    internal interface IUserRepository
    {
        DataSet GetAllTeachers();
        DataSet GetAllStudents();
        int UpdateProfile(User user);
        // User GetUserById(int id);
        bool UserExists(string username);
        int AddUser(User newuser);
        int GetNewUserId();
        // select * from users where Email=@email and password=@password
        User Login(string username, string password);
    }
}
