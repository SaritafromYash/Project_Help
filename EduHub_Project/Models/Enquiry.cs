using System.ComponentModel.DataAnnotations;

namespace EduHub_Project.Models
{
    public class Enquiry
    {
        [Key]
        public int EnquiryId { get; set; }
        public int CourseId {  get; set; }
        public int UserId { get; set; }
        public string? Subject { get; set; }
        public string Message { get; set; } = string.Empty;
        public DateTime EnquieryDate { get; set; }
        public string? Status {  get; set; }
        public string? Response { get; set; }    
    }
}