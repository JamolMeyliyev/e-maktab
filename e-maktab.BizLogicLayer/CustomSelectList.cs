using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Atttendance;
using e_maktab.BizLogicLayer.Models.Science;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer;

public static class CustomSelectList
{
    public static List<AttendanceAsSelectListDto> AttendanceSelectList(this IQueryable<Attendance> attendances)
    {
       return attendances.Select(val =>
        new AttendanceAsSelectListDto
        {
            ShortName = val.ShortName,
            Id = val.Id,
            
        }
        
        ).ToList();
    }
    public static List<ClassAsSelectListDto> ClassSelectList(this IQueryable<Class> entities)
    {
        return entities.Select(val =>
         new ClassAsSelectListDto
         {
             ShortName = val.ShortName,
             Id = val.Id,
             StateId = val.StateId

         }

         ).ToList();
    }
    public static List<ScienceAsSelectListDto> ScienceSelectList(this IQueryable<Science> entities)
    {
        return entities.Select(val =>
         new ScienceAsSelectListDto
         {
             ShortName = val.ShortName,
             Id = val.Id,
             StateId = val.StateId

         }

         ).ToList();
    }

    public static List<TeacherAsSelectListDto> TeacherSelectList(this IQueryable<Teacher> entities)
    {
        return entities.Select(val =>
         new TeacherAsSelectListDto
         {
             FirstName= val.FirstName,
             LastName= val.LastName,
             Id = val.Id,
             StateId = val.StateId
         }

         ).ToList();
    }

    public static List<OrganizationAsSelectListDto> TeacherSelectList(this IQueryable<Organization> entities)
    {
        return entities.Select(val =>
         new OrganizationAsSelectListDto
         {
             FullName= val.FullName,
             Inn = val.Inn,
             Id = val.Id,
             StateId = val.StateId
         }

         ).ToList();
    }
    public static List<LessonAsSlectListDto> LessonSelectList(this IQueryable<Lesson> entities)
    {
        return entities.Select(val =>
         new LessonAsSlectListDto
         {
             Id = val.Id,
             StateId = val.StateId,
             ScienceId= val.ScienceId
         }

         ).ToList();
    }

}
