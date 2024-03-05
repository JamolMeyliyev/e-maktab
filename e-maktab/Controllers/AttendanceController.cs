using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Atttendance;
using e_maktab.BizLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_maktab.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AttendanceController : ControllerBase
{
    private readonly IAttendanceService _service;
    private readonly ILessonAttendanceService _lAtService;
    public AttendanceController(IAttendanceService service,ILessonAttendanceService attendanceService)
    {
        _service = service;
        _lAtService = attendanceService;
    }
    
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAttendanceDto dto)
    {
        try
        {
            return Ok(await _service.Create(dto));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpGet]
    public IActionResult AsSelectList()
    {
        try
        {
            
            return Ok(_service.AsSelectList());
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            await _service.Delete(id);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> GetLessonStudents(int lessonId)
    {
        try
        {
            return Ok(await _lAtService.GetLessonStudents(lessonId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> GetUserLessons(int userId)
    {
        try
        {
            return Ok(await _lAtService.GetUserLessons(userId));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> SaveAttendanceByLesson([FromBody] CreateLessonAttendance dto)
    {
        try
        {
            await _lAtService.SaveAttendanceByLesson(dto);
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

}

