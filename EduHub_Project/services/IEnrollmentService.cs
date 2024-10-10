using EduHub_Project.Models;

namespace EduHub_Project.services
{
    public interface IEnrollmentService
    {
        Task<Enrollment> GetEnrollmentAsync(int enrollmentId);
        Task<IEnumerable<Enrollment>> GetEnrollmentsAsync();
        
        Task<Enrollment> CreateEnrollmentAsync(Enrollment newEnrollment);
        Task<Enrollment> UpdateEnrollmentAsync(int enrollmentId, Enrollment updatedEnrollment);
        Task<IEnumerable<Enrollment>>GetEnrollmentsByIdAsync(int UserId);
        Task<bool> DeleteEnrollmentAsync(int enrollmentId);
    }
}
