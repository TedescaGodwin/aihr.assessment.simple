using aihr.assessment.api.Courses.Api.Models.Dto;

namespace aihr.assessment.api.Courses.Api.Repositories.Interface
{
    public interface ICourseRepository
    {
        Task<IEnumerable<CourseDto>> GetCourses();
        Task<CourseDto> GetCourseById(int courseId);
        Task<CourseDto> CreateUpdateCourse(CourseDto courseDto);
        Task<bool> DeleteCourse(int courseId);
    }
}
