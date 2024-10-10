
using MVC_EduHub.Models;

namespace MVC_EduHub.services
{
    public interface IEnquiryService
    {
        Task<IEnumerable<Enquiry>> GetAllEnquiriesAsync();
        Task<Enquiry> GetEnquiryByIdAsync(int id);
        Task AddEnquiryAsync(Enquiry enquiry);
        Task UpdateEnquiryAsync(int id, Enquiry enquiry);
        Task DeleteEnquiryAsync(int id);
    }
}
