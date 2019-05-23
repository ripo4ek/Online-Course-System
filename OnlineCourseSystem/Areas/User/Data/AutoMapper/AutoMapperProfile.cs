using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineCourseSystem.Areas.User.Models;
using OnlineCourseSystem.Areas.User.Models.Dtos;
using OnlineCourseSystem.Domain.Model;
using OnlineCourseSystem.Domain.Model.Tasks;

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




            CreateMap<CoursePostViewModel, Course>();
            CreateMap<SectionPostViewModel, Section>();
            CreateMap<TopicPostViewModel, Topic>();
            CreateMap<QuizTaskPostViewModel, QuizTask>();
            CreateMap<QuestionTaskPostViewModel, QuestionTask>();
            CreateMap<TextTaskPostViewModel, TextTask>();
            CreateMap<VideoTaskPostViewModel, VideoTask>();
        }
    }
}
