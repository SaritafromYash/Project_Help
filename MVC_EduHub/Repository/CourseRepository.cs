
using Microsoft.EntityFrameworkCore;
using MVC_EduHub.Models;
using MVC_EduHub.services;

namespace MVC_EduHub.repository
{
    public class CourseRepository : ICourseService
    {
        private readonly AppDbContext _context;

        public CourseRepository(AppDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetCoursesByUserId(int id)
        {
            return _context.Courses.Where(c => c.UserId == id).ToList();
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return  _context.Courses.ToList();
        }

        public Course GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }

        public void AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
        }

        public void UpdateCourse(int id, Course course)
        {
            var existingCourse =  _context.Courses.Find(id);
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

            _context.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            var course =  _context.Courses.Find(id);
            if (course == null)
            {
                throw new Exception("Course not found");
            }

            _context.Courses.Remove(course);
             _context.SaveChanges();
        }

      

      
    }
}
