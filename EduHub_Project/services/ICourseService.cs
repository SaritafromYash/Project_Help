using EduHub_Project.Models;

namespace EduHub_Project.services
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync();
        Task<Course> GetCourseByIdAsync(int id);
        Task<IEnumerable<Course>> GetCoursesByUserIdAsync(int id);
        Task AddCourseAsync(Course course);
        Task UpdateCourseAsync(int id, Course course);
        Task DeleteCourseAsync(int id);
      
    }
}
