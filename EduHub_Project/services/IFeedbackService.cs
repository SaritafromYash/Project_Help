using EduHub_Project.Models;

namespace EduHub_Project.services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedback();
        Task<Feedback> GetFeedbackById(int id);
        Task<Feedback> AddFeedback(Feedback feedback);
       
    }
}
