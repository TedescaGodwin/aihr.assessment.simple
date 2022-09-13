using aihr.assessment.api.Courses.Api.Models;
using aihr.assessment.api.Courses.Api.Models.Dto;
using aihr.assessment.api.Courses.Api.Repositories.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace aihr.assessment.course.Controllers
{
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
        [ProducesResponseType(typeof(IEnumerable<Course>), (int)HttpStatusCode.OK)]
        public async Task<object> GetCourses()
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

        [Route("{id}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
        public async Task<object> GetCourseById(int id)
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
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
        public async Task<object> CreateCourse([FromBody] CourseDto courseDto)
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
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
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
        [ProducesResponseType(typeof(Course), (int)HttpStatusCode.OK)]
        public async Task<object> UpdateCourse(int id)
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
