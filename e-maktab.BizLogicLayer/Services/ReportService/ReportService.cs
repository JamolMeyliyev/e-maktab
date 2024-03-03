using AutoMapper;
using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using e_maktab.DataLayer.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WEBASE.Utility;

namespace e_maktab.BizLogicLayer.Services;

public class ReportService : IReportService
{
    private readonly IUserLessonAttendanceRepository _userLeAtRepos;
    private readonly ILessonRepository _lessonRepos;
    private readonly ILessonAttendanceService _lesAtService;
    private readonly IMapper _mapper;
    
    public ReportService(IUserLessonAttendanceRepository userLeAtRepos, ILessonRepository lessonRepos, ILessonAttendanceService lesAtService,IMapper mapper)
    {
        _userLeAtRepos = userLeAtRepos;
        _lessonRepos = lessonRepos;
        _lesAtService = lesAtService;
        _mapper = mapper;
    }

    public async Task<List<UserLessonAttendance>> GetUserAttenceCustomDate(int userId, DateOnly fromDate, DateOnly toDate)
    {
        List<UserLessonAttendance> result = new List<UserLessonAttendance>();
        var month = DateTime.Now.Month;
        var attendances = _userLeAtRepos.SelectAll().Where(s => s.UserId == userId);
        var lessons = _lessonRepos.SelectAll().Where(s => s.Day  >= fromDate && s.Day<=toDate).ToList();

        foreach (var lesson in lessons)
        {
            result.Concat(attendances.Where(s => s.LessonId == lesson.Id));
        }

        return result;
    }

    public async Task<List<UserLessonAttendance>> GetUserAttenceLastMonth(int userId)
    {
        List<UserLessonAttendance> result =  new List<UserLessonAttendance>();
        var month = DateTime.Now.Month;
        var lessons = await _lesAtService.GetUserLessons(userId);
        foreach(var lesson in lessons)
        {
            if (lesson.Day.Month == month)
            {
                result.Add(_userLeAtRepos.SelectAll().Where(s => s.LessonId == lesson.Id && s.UserId == userId).First());
            }
        }
        return result;
    }

    public async Task<List<UserLessonAttendance>> GetUserAttenceLastYear(int userId)
    {

        List<UserLessonAttendance> result = new List<UserLessonAttendance>();
        var month = DateTime.Now.Month;
        var attendances =  _userLeAtRepos.SelectAll().Where(s => s.UserId == userId);
        var lessons = _lessonRepos.SelectAll().Where(s => s.Day.Month == month).ToList();

        foreach(var lesson in lessons)
        {
            result.Concat(attendances.Where(s => s.LessonId == lesson.Id));
        }
       
        return result;
    }

    public async Task<ScheduleDto> WeeklyLessonSchedule(int userId)
    {
        var day = (int)DateTime.Now.DayOfWeek;
        var correctDay = DateTime.Now;
       
        if(day == 7)
        {
            day = 1;
            correctDay = DateTime.Now.AddDays(1);
        }
       
        var result = new ScheduleDto();
        var lessons = await _lesAtService.GetUserLessons(userId);
        
        for(int ed = day; ed <= 6; ed++)
        {
            
            var lessonOfday = lessons
                .Where(s => s.Day.Month == correctDay.Month && s.Day.Day == correctDay.Day)
                .OrderBy(s => s.StartDate);
            var daySchedule = new ScheduleDayDto()
            {
                DayOfWeekName = WeekDay(ed),
                Lessons = lessons
                
            };

            result.Days.Add(daySchedule);

            correctDay = correctDay.AddDays(1);


        }
        return result;

    }

    public async Task<ScheduleDto> WeeklyTeacherLessonSchedule(int teacherId)
    {
         var day = (int)DateTime.Now.DayOfWeek;
        var correctDay = DateTime.Now;
       
        if(day == 7)
        {
            day = 1;
            correctDay = DateTime.Now.AddDays(1);
        }
       
        var result = new ScheduleDto();
        var lessonEntities = await _lessonRepos.SelectAll().Where(s => s.TeacherId == teacherId).ToListAsync(); 
        
        var lessons = _mapper.Map<List<LessonDto>>(lessonEntities);

        for(int ed = day; ed <= 6; ed++)
        {
            
            var lessonOfday = lessons
                .Where(s => s.Day.Month == correctDay.Month && s.Day.Day == correctDay.Day)
                .OrderBy(s => s.StartDate);
            var daySchedule = new ScheduleDayDto()
            {
                DayOfWeekName = WeekDay(ed),
                Lessons = lessons
                
            };

            result.Days.Add(daySchedule);

            correctDay = correctDay.AddDays(1);


        }
        return result;
    }

    public string WeekDay(int day)
    {
        string result = string.Empty;
        switch(day)
        {
            case 1: result = "Monday";
                break;
            case 2:
                result = "Tuesday";
                break;
            case 3:
                result = "Wednesday";
                break;
            case 4:
                result = "Thursday";
                break;
            case 5:
                result = "Friday";
                break;
            case 6:
                result = "Saturday";
                break;
           
        }
        return result;
    }
}
