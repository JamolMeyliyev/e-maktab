using AutoMapper;
using e_maktab.BizLogicLayer.Models.Role;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Mapper;

public class HomeworkMapper : Profile
{
    public HomeworkMapper()
    {
        CreateMap<CreateHomeworkDto, Homework>();
        CreateMap<Homework, HomeworkDto>()
            .ForMember(s => s.State, s => s.MapFrom(s => s.State.FullName))
            .ForMember(s => s.Teacher,s => s.MapFrom(s => s.Teacher.FirstName))
            .ForMember(s => s.Lesson, s => s.MapFrom(s => s.Lesson.Name));

    }
}
