

using MVC_EduHub.Models;

namespace MVC_EduHub.services
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
