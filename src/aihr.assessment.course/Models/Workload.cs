namespace aihr.assessment.api.Models
{
    public class Workload
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public double HoursPerWeek { get; set; }
        public double WeeksToStudy { get; set; }
        public string? CourseName { get; set; }
    }
}
