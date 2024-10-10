using ADO_Layered_App_Demo.ServiceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using ADO_Layered_App_Demo.Models;

namespace ADO_Layered_App_Demo.Repository
{
    internal class UserRepository : IUserRepository
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static DataSet ds;
        static DataTable dt;
        public UserRepository()
        {
            string connection = "Data Source=YISC1601949LT\\SQLEXPRESS;initial catalog=Eduhubdb;integrated security=true;trustservercertificate=true";
            con = new SqlConnection(connection);
            //  Console.WriteLine("Connection established successfully!");
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

    public  User Login(string username, string password)
        { User? loginuser= null;
            User luser=new User();
            cmd.Parameters.Clear();
            cmd.CommandText = "select UserId,Username,Password,Email,Mobilenumber from users where Username=@username and password= @password";
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
           da=new SqlDataAdapter();
            ds= new DataSet();  
            da.SelectCommand = cmd;
            da.Fill(ds);
            
                dt=ds.Tables[0];

            if (dt.Rows.Count == 1)
            {
                
                loginuser.UserId = (int)dt.Rows[0]["UserId"];
                loginuser.Username = dt.Rows[0]["Username"].ToString();
                loginuser.Password = dt.Rows[0]["Password"].ToString();
                loginuser.Password = dt.Rows[0]["Email"].ToString();
                loginuser.Password = dt.Rows[0]["Mobilenumber"].ToString();
                return loginuser;
            }
            else return loginuser;
            
        }
        public DataSet GetAllTeachers()
        {
            cmd.CommandText = "select UserId,Username,Email,Mobilenumber,UserRole,ProfileImage" +
                " from Users where UserRole="+"'Educator'";
            da=new SqlDataAdapter();
            da.SelectCommand = cmd; 
            ds=new DataSet();
            da.Fill(ds);
          
            return ds;
               }

        public DataSet GetAllStudents()
        {
            cmd.CommandText = "select UserId,Username,Email,Mobilenumber,UserRole,ProfileImage" +
                " from Users where UserRole=" + "'Student'";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        public int UpdateProfile(User user)
        {
            try
            {

                cmd.Parameters.Clear();
                cmd.CommandText = "update users set Email=@email,Mobilenumber=@mobile,Profileimage=@profileimg where  Username=@username";
                cmd.Parameters.AddWithValue("@email", user.Email);
                cmd.Parameters.AddWithValue("@mobile", user.Mobilenumber);
                cmd.Parameters.AddWithValue("@profileimg", user.ProfileImage);
                cmd.Parameters.AddWithValue("@username", user.Username);
                con.Open();
                int result=cmd.ExecuteNonQuery();
                con.Close();
                return result;
            }

               catch(SqlException ex)
                            {
                 Console.WriteLine(ex.Message);
                              }

            return 0;
        }




        public int AddUser(User newuser)
        {
            try
            {   cmd.Parameters.Clear();
                cmd.CommandText = "insert into Users(username,password,email,mobilenumber,userrole,profileimage)values(@username,@password,@email,@mobile,@role,@profileimg)";
                cmd.Parameters.AddWithValue("@username", newuser.Username);
                cmd.Parameters.AddWithValue("@password", newuser.Password);
                cmd.Parameters.AddWithValue("@email", newuser.Email);
                cmd.Parameters.AddWithValue("@mobile", newuser.Mobilenumber);
                cmd.Parameters.AddWithValue("@role", newuser.UserRole);
                cmd.Parameters.AddWithValue("@profileimg", newuser.ProfileImage);
                con.Open();
                int result = cmd.ExecuteNonQuery();
                con.Close();
                return result;

            }

            catch(SqlException ex) {

                Console.WriteLine(ex.Message);
            }
            return 0;
        }




        public bool UserExists(string username)
        {
            cmd.CommandText = "select Count(username) from users where username=@username";
            cmd.Parameters.AddWithValue ("@username", username);
            con.Open();
            int result=(int)cmd.ExecuteScalar();
            con.Close();
            if (result == 1)
            {
                return true;
            }
            else
               
           return false;

           
        }
        public int GetNewUserId()
        {
            cmd.CommandText = "select max(userId) from users";
            con.Open();
            int ID = (int)cmd.ExecuteScalar();
            return ID;
        }


    }
}
