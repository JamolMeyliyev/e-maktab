using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_maktab.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ReportController : ControllerBase
{
    private readonly IReportService _service;
    public ReportController(IReportService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<IActionResult> GetUserAttenceLastMonth(int userId)
    {
        try
        {
            return Ok(await _service.GetUserAttenceLastMonth(userId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> GetUserAttenceLastYear(int userId)
    {
        try
        {
            return Ok(await _service.GetUserAttenceLastYear(userId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> GetUserAttenceCustomDate(int userId, DateOnly fromDate, DateOnly toDate)
    {
        try
        {
            return Ok(await _service.GetUserAttenceCustomDate(userId,fromDate,toDate));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> WeeklyLessonSchedule(int userId)
    {
        try
        {
            return Ok(await _service.WeeklyLessonSchedule(userId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> WeeklyTeacherLessonSchedule(int teacherId)
    {
        try
        {
            return Ok(await _service.WeeklyTeacherLessonSchedule(teacherId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}
//Task<List<UserLessonAttendance>> GetUserAttenceLastMonth(int userId);
//Task<List<UserLessonAttendance>> GetUserAttenceLastYear(int userId);
//Task<List<UserLessonAttendance>> GetUserAttenceCustomDate(int userId, DateOnly fromDate, DateOnly toDate);

//Task<ScheduleDto> WeeklyLessonSchedule(int userId);
//Task<ScheduleDto> WeeklyTeacherLessonSchedule(int teacherId);