using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.repository
{
    public class EnquiryRepository : IEnquiryService
    {
        private readonly AppDbContext _context;

        public EnquiryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Enquiry>> GetAllEnquiriesAsync()
        {
            return await _context.Enquiries.ToListAsync();
        }

        public async Task<Enquiry> GetEnquiryByIdAsync(int id)
        {
            return await _context.Enquiries.FindAsync(id);
        }

        public async Task AddEnquiryAsync(Enquiry enquiry)
        {
            await _context.Enquiries.AddAsync(enquiry);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateEnquiryAsync(int id, Enquiry enquiry)
        {
            var existingEnquiry = await _context.Enquiries.FindAsync(id);
            if (existingEnquiry == null)
            {
                throw new Exception("Enquiry not found");
            }

            //existingEnquiry.CourseId = enquiry.CourseId;
            //existingEnquiry.UserId = enquiry.UserId;
            //existingEnquiry.Subject = enquiry.Subject;
            //existingEnquiry.Message = enquiry.Message;
          //  existingEnquiry.EnquieryDate = enquiry.EnquieryDate;
            existingEnquiry.Status = enquiry.Status;
            existingEnquiry.Response = enquiry.Response;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteEnquiryAsync(int id)
        {
            var enquiry = await _context.Enquiries.FindAsync(id);
            if (enquiry == null)
            {
                throw new Exception("Enquiry not found");
            }

            _context.Enquiries.Remove(enquiry);
            await _context.SaveChangesAsync();
        }
    }
}
