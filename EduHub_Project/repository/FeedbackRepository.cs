using EduHub_Project.Models;
using EduHub_Project.services;
using Microsoft.EntityFrameworkCore;

namespace EduHub_Project.repository
{
    public class FeedbackRepository : IFeedbackService
    {
        private readonly AppDbContext _context;

        public FeedbackRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedback()
        {
            return await _context.Set<Feedback>().ToListAsync();
        }

        public async Task<Feedback> GetFeedbackById(int id)
        {
            return await _context.Set<Feedback>().FindAsync(id);
        }

        public async Task<Feedback> AddFeedback(Feedback feedback)
        {
            _context.Set<Feedback>().Add(feedback);
            await _context.SaveChangesAsync();
            return feedback;
        }
    }
}
