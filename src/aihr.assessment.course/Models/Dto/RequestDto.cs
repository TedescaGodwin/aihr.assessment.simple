using aihr.assessment.api.Courses.Api.Models.Dto;

namespace aihr.assessment.api.Models.Dto
{
    public class RequestDto
    {
        public int StudentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CourseDto> Courses { get; set; } = new();
    }
}
