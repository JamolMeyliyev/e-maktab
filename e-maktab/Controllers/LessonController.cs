using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_maktab.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class LessonController : ControllerBase
{
    private ILessonService _service;
    public LessonController(ILessonService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetList([FromQuery] LessonListSortFilterOptions options)
    {
        try
        {
            return Ok(_service.GetList(options));
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
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLessonDto dto)
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
    public async Task<IActionResult> Get(int id)
    {
        try
        {
            return Ok(await _service.Get(id));
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLessonDto dto)
    {
        try
        {
            await _service.Update(dto);
            return Ok();
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
}