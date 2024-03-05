using AutoMapper;
using e_maktab.BizLogicLayer.Models.Organization;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Mapper;

public class OrganizationMapper:Profile
{
    public OrganizationMapper() 
    {
        CreateMap<CreateOrganizationDto, Organization>()
            .ForMember(s => s.DateOfCreated,s => s.MapFrom(s => DateTime.Now))
            ;
        CreateMap<Organization, OrganizationDto>().ForMember(s => s.State, s => s.MapFrom(s => s.State.FullName));
    }
}
