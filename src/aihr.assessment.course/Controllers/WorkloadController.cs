using aihr.assessment.api.Courses.Api.Models.Dto;
using aihr.assessment.api.Courses.Api.Repositories;
using aihr.assessment.api.Courses.Api.Repositories.Interface;
using aihr.assessment.api.Models;
using aihr.assessment.api.Models.Dto;
using Microsoft.AspNetCore.Mvc;

namespace aihr.assessment.course.Controllers
{
    [Route("api/workload")]
    public class WorkloadController : ControllerBase
    {
        protected ResponseDto _response;
        private IWorkloadRepository _workloadRepository;
        public WorkloadController(IWorkloadRepository workloadRepository)
        {
            _response = new ResponseDto();
            _workloadRepository = workloadRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<WorkloadDto> workloadDtos = await _workloadRepository.GetWorkloadHistory();
                _response.Result = workloadDtos;
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
        [Route("{studentId}")]
        public async Task<object> Get(int studentId)
        {
            try
            {
                var workloadDtos = await _workloadRepository.GetWorkloadByStudentId(studentId);
                _response.Result = workloadDtos;
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
        public async Task<object> Post([FromBody] RequestDto requestDto)
        {
            try
            {
                if (requestDto != null)
                {
                    List<WorkloadDto> load = new();
                    var remainTime = requestDto.EndDate.Subtract(requestDto.StartDate).TotalMinutes;

                    foreach (var course in requestDto.Courses)
                    {
                        if (course != null)
                        {
                            var totalMinutes = course.Hours * 60 / remainTime;
                            WorkloadDto workload = new()
                            {
                                StudentId = requestDto.StudentId,
                                HoursToStudy = totalMinutes / 60,
                                WeeksToStudy = Math.Round(totalMinutes / 60 / 56),  //Assumption of 8hrs to study per day
                                CourseName = course.Name,
                            };
                            load.Add(workload);
                        }
                    }

                    var model = await _workloadRepository.CreateUpdateWorkload(load);
                    _response.Result = model;
                }

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
