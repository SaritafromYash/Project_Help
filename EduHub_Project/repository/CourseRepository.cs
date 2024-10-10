using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.repository
{
    public class CourseRepository : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await _context.Courses.ToListAsync();
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _context.Courses.FindAsync(id);
        }

        public async Task AddCourseAsync(Course course)
        {
            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCourseAsync(int id, Course course)
        {
            var existingCourse = await _context.Courses.FindAsync(id);
            if (existingCourse == null)
            {
                throw new Exception("Course not found");
            }

            existingCourse.Title = course.Title;
            existingCourse.Description = course.Description;
            existingCourse.CourseStartDate = course.CourseStartDate;
            existingCourse.CourseEndDate = course.CourseEndDate;
            existingCourse.UserId = course.UserId;
            existingCourse.Category = course.Category;
            existingCourse.Level = course.Level;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteCourseAsync(int id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                throw new Exception("Course not found");
            }

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetCoursesByUserIdAsync(int id)
        {
            return await _context.Courses.Where(c=>c.UserId==id).ToListAsync();
        }

      
    }
}
