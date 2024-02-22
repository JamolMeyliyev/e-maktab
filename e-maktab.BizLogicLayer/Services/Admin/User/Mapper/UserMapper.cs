﻿using AutoMapper;
using e_maktab.DataLayer.Entities;

namespace e_maktab.BizLogicLayer.Services;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserDto, User>()
         .ForMember(s => s.DateOfCreated, p => p.MapFrom(s => DateTime.UtcNow))
         .ForMember(s => s.StateId, s => s.MapFrom(s => 1));


    }
}
