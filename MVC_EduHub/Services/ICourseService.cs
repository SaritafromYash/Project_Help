
using MVC_EduHub.Models;

namespace MVC_EduHub.services
{
    public interface ICourseService
    {
        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int id);
        IEnumerable<Course> GetCoursesByUserId(int id);
        void  AddCourse(Course course);
        void UpdateCourse(int id, Course course);
        void DeleteCourse(int id);
      
    }
}
