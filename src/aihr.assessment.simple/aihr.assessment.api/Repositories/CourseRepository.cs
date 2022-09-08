using aihr.assessment.api.Courses.Api.DbContexts;
using aihr.assessment.api.Courses.Api.Models;
using aihr.assessment.api.Courses.Api.Models.Dto;
using aihr.assessment.api.Courses.Api.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
namespace aihr.assessment.api.Courses.Api.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public CourseRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<CourseDto> CreateUpdateCourse(CourseDto courseDto)
        {
            Course course = _mapper.Map<CourseDto, Course>(courseDto);
            if (course.CourseId > 0)
            {
                _db.Courses.Update(course);
            }
            else
            {
                _db.Courses.Add(course);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Course, CourseDto>(course);
        }

        public async Task<bool> DeleteCourse(int courseId)
        {
            try
            {
                var course = await _db.Courses.FirstOrDefaultAsync(u => u.CourseId == courseId);
                if (course == null)
                {
                    return false;
                }
                _db.Courses.Remove(course);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<CourseDto> GetCourseById(int courseId)
        {
            var course = await _db.Courses.Where(x => x.CourseId == courseId).FirstOrDefaultAsync();
            return _mapper.Map<CourseDto>(course);
        }

        public async Task<IEnumerable<CourseDto>> GetCourses()
        {
            List<Course> courseList = await _db.Courses.ToListAsync();
            return _mapper.Map<List<CourseDto>>(courseList);
        }
    }
}
