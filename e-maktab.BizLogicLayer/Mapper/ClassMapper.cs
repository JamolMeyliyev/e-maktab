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
            .ForMember(s => s.Users,s => s.MapFrom(s => s.Users.Select(s => new UserDto()
            {
                Id = s.Id,
                OrganizationId = s.OrganizationId,
                PhoneNumber = s.PhoneNumber,
                LastName = s.LastName,
                FirstName = s.FirstName,
                Email = s.Email,
                StateId = s.StateId
            }).ToList()));
    }
}
