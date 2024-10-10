using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.repository
{
    public class EnrollmentRepository:IEnrollmentService
    {
        private readonly AppDbContext _context;

        public EnrollmentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Enrollment> GetEnrollmentAsync(int enrollmentId)
        {
            return await _context.Enrollments.FindAsync(enrollmentId);
        }

        public async Task<IEnumerable<Enrollment>> GetAllEnrollmentsAsync()
        {
            return await _context.Enrollments.ToListAsync();
        }
        public async Task<IEnumerable<Enrollment>>GetEnrollmentsByIdAsync(int id)
        {
            return await _context.Enrollments.Where(e=>e.UserId == id).ToListAsync();
        }

        public async Task<Enrollment> CreateEnrollmentAsync(Enrollment newEnrollment)
        {
            _context.Enrollments.Add(newEnrollment);
            await _context.SaveChangesAsync();
            return newEnrollment;
        }

        public async Task<Enrollment> UpdateEnrollmentAsync(int enrollmentId, Enrollment updatedEnrollment)
        {
            var existingEnrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (existingEnrollment == null)
                return null;

           // existingEnrollment.UserId = updatedEnrollment.UserId;
          //  existingEnrollment.CourseId = updatedEnrollment.CourseId;
           // existingEnrollment.EnrollmentDate = updatedEnrollment.EnrollmentDate;
            existingEnrollment.Status = updatedEnrollment.Status;

            await _context.SaveChangesAsync();
            return existingEnrollment;
        }

        public async Task<bool> DeleteEnrollmentAsync(int enrollmentId)
        {
            var enrollment = await _context.Enrollments.FindAsync(enrollmentId);
            if (enrollment == null)
                return false;

            _context.Enrollments.Remove(enrollment);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Enrollment>> GetEnrollmentsAsync()
        {
           var studlist=await _context.Enrollments.ToListAsync();
            return studlist;
        }

        
    }
}
