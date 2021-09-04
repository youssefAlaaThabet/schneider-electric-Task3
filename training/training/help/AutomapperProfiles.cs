using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using training.help.docs;
using training.help.dtos;
using training.Models;
using training.modes;

namespace training.help
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            //CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<StudentCourse, StudentCourseDto>().ReverseMap();
            //.ForMember(dest => dest.summary, opt => 
            // opt.MapFrom(src => src.Name + " "+ src.Gpa)); }



        }
    }
}
