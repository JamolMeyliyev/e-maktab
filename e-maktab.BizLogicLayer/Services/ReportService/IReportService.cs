using e_maktab.BizLogicLayer.Models;
using e_maktab.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_maktab.BizLogicLayer.Services;

public interface IReportService
{
    Task<List<UserLessonAttendance>> GetUserAttenceLastMonth(int userId);
    Task<List<UserLessonAttendance>> GetUserAttenceLastYear(int userId);
    Task<List<UserLessonAttendance>> GetUserAttenceCustomDate(int userId,DateOnly fromDate,DateOnly toDate);

    Task<ScheduleDto> WeeklyLessonSchedule(int userId);
    Task<ScheduleDto> WeeklyTeacherLessonSchedule(int teacherId);

}
