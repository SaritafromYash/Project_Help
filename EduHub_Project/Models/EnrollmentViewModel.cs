using System.ComponentModel.DataAnnotations;

namespace EduHub_Project.Models
{
    public class EnrollmentViewModel
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int UserId {  get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string Title { get; set; }
        public DateTime  courseStartDate { get; set; }
        public DateTime courseEndDate { get; set; }
        public string Status { get; set; }

    }
}
