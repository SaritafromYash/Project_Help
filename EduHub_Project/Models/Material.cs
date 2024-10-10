using System.ComponentModel.DataAnnotations;

namespace EduHub_Project.Models
{
    public class Material
    {
        [Key]
        public int MaterialId { get; set; }
        public int CourseId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? URL { get; set; }
        public DateTime  UploadDate{ get; set; }
        public string? ContentType { get; set; }
       
    }
}