using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services;
using e_maktab.BizLogicLayer.Services.Admin;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_maktab.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class TeacherController : ControllerBase
{

    private ITeacherService _service;
    public TeacherController(ITeacherService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetList([FromQuery] TeacherListSortFilterOptions options)
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
            _service.AsSelectList();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateTeacherDto dto)
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
    public async Task<IActionResult> Update([FromBody] UpdateTeacherDto dto)
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
