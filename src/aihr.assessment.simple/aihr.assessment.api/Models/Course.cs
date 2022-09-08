

using System.ComponentModel.DataAnnotations;

namespace aihr.assessment.api.Courses.Api.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Hours { get; set; }
    }
}
