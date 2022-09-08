using aihr.assessment.api.Courses.Api.Models;
using aihr.assessment.api.Courses.Api.Models.Dto;
using aihr.assessment.api.Models.Dto;
using aihr.assessment.api.Models;
using AutoMapper;
using System.Collections.Generic;

namespace aihr.assessment.api
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<CourseDto, Course>();
                config.CreateMap<Course, CourseDto>();
                config.CreateMap<WorkloadDto, Workload>();
                config.CreateMap<Workload, WorkloadDto>();
            });

            return mappingConfig;
        }
    }
}
