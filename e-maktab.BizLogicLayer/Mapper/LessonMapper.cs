

using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;

namespace e_maktab.BizLogicLayer.Mapper;

public class LessonMapper:Profile
{
    public LessonMapper()
    {


        CreateMap<Lesson, LessonDto>().ForMember(s => s.State, s => s.MapFrom(s => s.State.FullName))
            .ForMember(s => s.Science, s => s.MapFrom(s => s.Science.FullName))
            .ForMember(s => s.Teacher,s => s.MapFrom(s => s.Teacher.FirstName))
            .ForMember(s => s.Homeworks,s => s.MapFrom(s => s.Homeworks.Select(s => 
            new HomeworkDto()
            {
                Id = s.Id,
                FullText = s.FullText,
                Title = s.Title,
                Teacher = s.Teacher.FirstName,
                TeacherId = s.TeacherId
            }).ToList()));
    }
}
