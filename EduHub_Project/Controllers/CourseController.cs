using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHub_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet]
       // [Authorize(Roles ="Educator,Student")]
        public async Task<ActionResult<IEnumerable<Course>>> GetAllCourses()
        {
            var courses = await _courseService.GetAllCoursesAsync();
            return Ok(courses);
        }
        [HttpGet]
        [Route("GetCoursesByUserId/{id}")]
       // [Authorize(Roles ="Educator")]
        public async Task<ActionResult<IEnumerable<Course>>> GetCoursesByUserId(int id)
        {
            var courses = await _courseService.GetCoursesByUserIdAsync(id);
            return Ok(courses);
        }




        [HttpGet("{id}")]
        
        public async Task<ActionResult<Course>> GetCourseById(int id)
        {
            var course = await _courseService.GetCourseByIdAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            return course;
        }
        [HttpPost]
        [Authorize(Roles ="Educator")]
        public async Task<ActionResult<Course>> AddCourse(Course course)
        {
            await _courseService.AddCourseAsync(course);
            return CreatedAtAction(nameof(GetCourseById), new { id = course.CourseId }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCourse(int id, Course course)
        {
            try
            {
                await _courseService.UpdateCourseAsync(id, course);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(int id)
        {
            try
            {
                await _courseService.DeleteCourseAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}

