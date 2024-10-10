using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub.Models
{
    public class Feedback
    {
        [Key]
        
        public int FeedBackId { get; set; }
        public int userId { get; set;}
        public string? feedbackmsg { get; set; }
        public DateTime feedbackdate { get; set; }
    }
}
