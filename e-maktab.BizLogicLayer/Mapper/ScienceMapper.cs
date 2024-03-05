using AutoMapper;
using e_maktab.BizLogicLayer.Models.Role;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using e_maktab.BizLogicLayer.Models.Science;

namespace e_maktab.BizLogicLayer.Mapper;

public class ScienceMapper : Profile
{
    public ScienceMapper()
    {
        CreateMap<CreateScienceDto, Science>();
        CreateMap<Science, ScienceDto>()
            .ForMember(s => s.State, s => s.MapFrom(s => s.State.FullName));
            

    }
}

