﻿using System.ComponentModel.DataAnnotations;

namespace MVC_EduHub.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentId { get; set; }
        public int UserId { get; set;}
        public int CourseId { get; set;}
        public DateTime EnrollmentDate { get; set; }
        public string? Status { get; set;}

    }
}