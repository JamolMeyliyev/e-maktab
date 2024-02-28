using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Mapper;

public class TeacherMapper : Profile
{
    public TeacherMapper()  
    {
        CreateMap<CreateTeacherDto, Teacher>()
               .ForMember(s => s.DateOfCreated, s => s.MapFrom(s => DateTime.Now))
               ;
        CreateMap<Teacher, TeacherDto>();
    }
}
