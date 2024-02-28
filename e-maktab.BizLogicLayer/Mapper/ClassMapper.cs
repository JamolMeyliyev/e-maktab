using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;

namespace e_maktab.BizLogicLayer.Mapper;

public class ClassMapper : Profile
{
    public ClassMapper()
    {
        CreateMap<CreateClassDto, Class>()
               .ForMember(s => s.DateOfCreated, s => s.MapFrom(s => DateTime.Now));
        CreateMap<Class, ClassDto>();
    }
}
