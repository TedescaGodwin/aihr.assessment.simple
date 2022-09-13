using aihr.assessment.api.Courses.Api.Models.Dto;
using aihr.assessment.api.Courses.Api.Repositories.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace aihr.assessment.course.Controllers
{
    [Route("api/course")]
    public class CourseController : ControllerBase
    {
        protected ResponseDto _response;
        private ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _response = new ResponseDto();
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<CourseDto> courseDtos = await _courseRepository.GetCourses();
                _response.Result = courseDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                var courseDtos = await _courseRepository.GetCourseById(id);
                _response.Result = courseDtos;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPost]
        public async Task<object> Post([FromBody] CourseDto courseDto)
        {
            try
            {
                var model = await _courseRepository.CreateUpdateCourse(courseDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }


        [HttpPut]
        public async Task<object> Put([FromBody] CourseDto courseDto)
        {
            try
            {
                var model = await _courseRepository.CreateUpdateCourse(courseDto);
                _response.Result = model;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isSuccess = await _courseRepository.DeleteCourse(id);
                _response.Result = isSuccess;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages
                     = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
