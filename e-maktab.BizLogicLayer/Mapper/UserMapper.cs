using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Role;
using e_maktab.DataLayer.Entities;


namespace e_maktab.BizLogicLayer.Mapper;

public class UserMapper:Profile
{
    public UserMapper() 
    {
        CreateMap<CreateUserDto, User>()
            .ForMember(s => s.DateOfCreated, s => s.MapFrom(p => DateTime.Now));
        CreateMap<User, UserDto>().ForMember(s => s.State, s => s.MapFrom(s => s.State.FullName))
            .ForMember(s => s.Organization, s => s.MapFrom(s => s.Organization.FullName))
            .ForMember(s => s.Login,s => s.MapFrom(s => s.Login))
            .ForMember(s => s.Roles, s => s.MapFrom(s => s.UserRoles.Select(s =>
               new RoleDto()
               {
                   Id = s.Id,
                   FullName = s.Role.FullName,
                   ShortName = s.Role.ShortName,
                   IsAdmin = s.Role.IsAdmin,
                   State = s.Role.State.FullName,
                   StateId = s.Role.StateId
               }).ToList()));


        CreateMap<CreateUserDto, Teacher>();
    }

}
