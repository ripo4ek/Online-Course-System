using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineCourseSystem.Areas.User.Models.Dtos;
using OnlineCourseSystem.Domain.Model;

namespace OnlineCourseSystem.Areas.User.Data.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Author, AuthorDto>();
            CreateMap<Direction, DirectionDto>();
            CreateMap<University, UniversityDto>();
            CreateMap<Course, CourseDto>();
        }
    }
}
