using aihr.assessment.api.Courses.Api.Models;
using aihr.assessment.api.Courses.Api.Models.Dto;
using AutoMapper;

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
            });

            return mappingConfig;
        }
    }
}
