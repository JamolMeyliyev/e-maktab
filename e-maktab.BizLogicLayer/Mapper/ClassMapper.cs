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
        CreateMap<Class, ClassDto>()
            .ForMember(s => s.State,s => s.MapFrom(s => s.State.FullName))
            .ForMember(s => s.Teacher,s => s.MapFrom(s => s.Teacher.FirstName))
            .ForMember(s => s.Lessons,s => s.MapFrom(s => s.Lessons
            .Select(s => new LessonDto()
            {
                Id = s.Id,
                Name= s.Name,
                ScienceId= s.ScienceId,
                LessonDay= s.LessonDay,
                StartTime= s.StartTime, 
                Science = s.Science.FullName,
                Teacher = s.Teacher.FirstName +" "+ s.Teacher.LastName,
                State= s.State.FullName,
                StateId = s.StateId,
                ClassId= s.ClassId,

            }).ToList()))
            .ForMember(s => s.Users,s => s.MapFrom(s => s.UserClasses.Select(s => new UserDto()
            {
                Id = s.Id,
                OrganizationId = s.User.OrganizationId,
                PhoneNumber = s.User.PhoneNumber,
                LastName = s.User.LastName,
                FirstName = s.User.FirstName,
                Email = s.User.Email,
                StateId = s.User.StateId
            }).ToList()));
    }
}
