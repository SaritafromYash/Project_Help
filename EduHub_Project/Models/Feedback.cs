using System.ComponentModel.DataAnnotations;

namespace EduHub_Project.Models
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
