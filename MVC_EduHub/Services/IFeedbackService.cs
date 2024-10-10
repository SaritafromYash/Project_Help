
using MVC_EduHub.Models;

namespace MVC_EduHub.services
{
    public interface IFeedbackService
    {
        Task<IEnumerable<Feedback>> GetAllFeedback();
        Task<Feedback> GetFeedbackById(int id);
        Task<Feedback> AddFeedback(Feedback feedback);
       
    }
}
