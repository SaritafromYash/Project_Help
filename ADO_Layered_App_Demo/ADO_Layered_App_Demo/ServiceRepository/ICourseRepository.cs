using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ADO_Layered_App_Demo.Models;

namespace ADO_Layered_App_Demo.ServiceRepository
{
    internal interface ICourseRepository
    {
        //select * from courses 
        DataSet GetAllCourses();
        //select * from coures where CourseId=@id
        Course GetCourseById(int id);
        //select * from courses where userid=@id
        DataSet GetCoursesByUser(int userid);
        // insert into courses (title,description,strdt,endt,userid,category,level)values(@title  .......)
        int AddCourse(Course course);
        int UpdateCourse(Course course);


    }
}
