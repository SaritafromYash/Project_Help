using Azure.Core;
using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnrollController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;
        private readonly AppDbContext _context;

        public EnrollController(IEnrollmentService enrollmentService,AppDbContext context)
        {
            _enrollmentService = enrollmentService;
            _context=context;
        }


        [HttpGet("{enrollmentId}")]
        public async Task<IActionResult> GetEnrollment(int enrollmentId)
        {
            var enrollment = await _enrollmentService.GetEnrollmentAsync(enrollmentId);
            if (enrollment == null)
                return NotFound();

            return Ok(enrollment);
        }
        [HttpGet("GetEnrollByUserId/{id}")]
      //  [Route("GetEnrollByUserId/{id}")]
        public async Task<IActionResult> GetEnrollByUserId(int id)
        {
           var enrollments= await _enrollmentService.GetEnrollmentsByIdAsync(id);
            if (enrollments == null)
                return NotFound();
            else
                return Ok(enrollments);
        }
        [HttpGet]
        public async Task<IActionResult>GetEnrollments()
        {
            var enrollments = await _enrollmentService.GetEnrollmentsAsync();
            return Ok(enrollments);
        }

        [HttpGet]
        [Route("GetAllEnrollments")]
        public async Task<ActionResult> GetAllEnrollments()
        {
           var students =await _context.AllEnrollments
          .FromSqlInterpolated($"EXEC SP_EnrolledStudents")
          .ToListAsync();

            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEnrollment(Enrollment newEnrollment)
        {
            var createdEnrollment = await _enrollmentService.CreateEnrollmentAsync(newEnrollment);
            return CreatedAtAction(nameof(GetEnrollment), new { enrollmentId = createdEnrollment.EnrollmentId }, createdEnrollment);
        }

        [HttpPut("{enrollmentId}")]
        public async Task<IActionResult> UpdateEnrollment(int enrollmentId, Enrollment updatedEnrollment)
        {
            var enrollment = await _enrollmentService.UpdateEnrollmentAsync(enrollmentId, updatedEnrollment);
            if (enrollment == null)
                return NotFound();

            return Ok(enrollment);
        }

        [HttpDelete("{enrollmentId}")]
        public async Task<IActionResult> DeleteEnrollment(int enrollmentId)
        {
            var result = await _enrollmentService.DeleteEnrollmentAsync(enrollmentId);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
