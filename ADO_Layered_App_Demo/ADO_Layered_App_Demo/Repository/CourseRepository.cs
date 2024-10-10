using ADO_Layered_App_Demo.Models;
using ADO_Layered_App_Demo.ServiceRepository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ADO_Layered_App_Demo.Repository
{
    internal class CourseRepository : ICourseRepository
    {
        static SqlConnection con;
        static SqlCommand cmd;
        static SqlDataAdapter da;
        static DataSet ds;
        static DataTable dt;



        public CourseRepository() {
            string connection = "Data Source=YISC1601949LT\\SQLEXPRESS;initial catalog=Eduhubdb;integrated security=true;trustservercertificate=true";
            con = new SqlConnection(connection);
            //  Console.WriteLine("Connection established successfully!");
            cmd = new SqlCommand();
            cmd.Connection = con;

        }
        public DataSet GetAllCourses()
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_GetAllCourses";
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public int AddCourse(Course course)
        {
            cmd.Parameters.Clear();
            cmd.CommandType= CommandType.StoredProcedure;
            cmd.CommandText = "SP_AddCourse";

            cmd.Parameters.AddWithValue("@title",course.Title);
            cmd.Parameters.AddWithValue("@description", course.Description);
            cmd.Parameters.AddWithValue("@startDate", course.StartDate);
            cmd.Parameters.AddWithValue("@endDate", course.EndDate);
            cmd.Parameters.AddWithValue("@cateogory", course.Category);
            cmd.Parameters.AddWithValue("@level", course.Level);
            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return 0;
        }

        public Course GetCourseById(int id)
        {
            cmd.CommandText = "exec SP_GetCourseById @courseid";
            cmd.Parameters.AddWithValue("@courseid", id);
            Course  course = new Course();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            ds = new DataSet();
            da.Fill(ds);
            DataRow dr= ds.Tables[0].Rows[0];
            course.CourseId = (int)dr["courseid"];
            course.Title = (string)dr["title"];
            course.Description = (string)dr["description"];
            course.StartDate = (DateTime)dr["startdate"];
            course.EndDate = (DateTime)dr["enddate"];
            course.Category = (string)dr["category"];
            course.Level = (string)dr["level"];
            return course;
        }

        public DataSet GetCoursesByUser(int userid)
        {

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_GetCoursebyuserid";
            cmd.Parameters.AddWithValue("@userid", userid);
            ds = new DataSet();
            da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            da.Fill(ds);
            return ds;

            
  
        }

        public int UpdateCourse(Course course)
        {
            cmd.Parameters.Clear();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SP_UpdateCourse";
            cmd.Parameters.AddWithValue("@courseId",course.CourseId);
            cmd.Parameters.AddWithValue("@title", course.Title);
            cmd.Parameters.AddWithValue("@description", course.Description);
            cmd.Parameters.AddWithValue("@startDate", course.StartDate);
            cmd.Parameters.AddWithValue("@endDate", course.EndDate);
            cmd.Parameters.AddWithValue("@cateogory", course.Category);
            cmd.Parameters.AddWithValue("@level", course.Level);

            con.Open();
            int res = cmd.ExecuteNonQuery();
            con.Close();
            return res;

        }
    }
}
