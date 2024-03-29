﻿using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Atttendance;
using e_maktab.BizLogicLayer.Models.Organization;
using e_maktab.BizLogicLayer.Models.Science;
using e_maktab.DataLayer.Entities;


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
             Name = val.Name,
             
         }

         ).ToList();
    }
    public static List<HomeworkAsSelectListDto> HomeworkSelectList(this IQueryable<Homework> entities)
    {
        return entities.Select(val =>
         new HomeworkAsSelectListDto
         {
             Id = val.Id,
             StateId = val.StateId,
             Title= val.Title
         }

         ).ToList();
    }
    public static List<UserAsSelectListDto> UserSelectList(this IQueryable<User> entities)
    {
        return entities.Select(val =>
         new UserAsSelectListDto
         {
             FirstName= val.FirstName,
             LastName= val.LastName,
             StateId= val.StateId,
            
         }

         ).ToList();
    }
    public static List<RoleAsSelectListDto> RoleSelectList(this IQueryable<Role> entities)
    {
        return entities.Select(val =>
         new RoleAsSelectListDto
         {
             Id = val.Id,
             FullName = val.FullName
         }

         ).ToList();
    }

}
