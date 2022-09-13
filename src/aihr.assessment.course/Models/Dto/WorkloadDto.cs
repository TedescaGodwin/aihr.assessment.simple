namespace aihr.assessment.api.Models.Dto
{
    public class WorkloadDto
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public double HoursToStudy { get; set; }
        public double WeeksToStudy { get; set; }
        public string CourseName { get; set; }
    }
}
