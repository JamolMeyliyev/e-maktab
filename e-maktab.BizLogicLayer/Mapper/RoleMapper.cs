
using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Role;
using e_maktab.DataLayer.Entities;

namespace e_maktab.BizLogicLayer.Mapper;

public class RoleMapper:Profile
{
    public RoleMapper() 
    {
        CreateMap<CreateRoleDto, Role>().ForMember(s => s.DateOfCreated, s => s.MapFrom(p => DateTime.Now));
        CreateMap<Role, RoleDto>().ForMember(s => s.Modules, s => s.MapFrom(s => s.RoleModules.Select(s => 
        new ModuleDto
        {
            ShortName = s.Module.ShortName,
            Id = s.Module.Id,
            StateId= s.Module.StateId
        }
        
        )));

    }
}
