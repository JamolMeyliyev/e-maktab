using AutoMapper;
using e_maktab.BizLogicLayer.Models.Atttendance;
using e_maktab.BizLogicLayer.Models.Science;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Mapper;

public class AttendanceMapper : Profile
{
    public AttendanceMapper()
    {
        CreateMap<CreateAttendanceDto, Attendance>();
        CreateMap<Attendance, AttendanceDto>();
           

    }
}
