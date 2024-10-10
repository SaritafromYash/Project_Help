using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Layered_App_Demo.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string?   Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UserId { get; set; }
        public string? Category { get; set; }
        public string? Level { get; set; }

        public  override string ToString()
        {
            return $" {CourseId} - {Title} - {Description} -{ StartDate} -{EndDate} - {UserId} - {Category} - {Level} ";
        }
    }
}
