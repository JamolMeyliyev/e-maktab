using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Role;
using e_maktab.BizLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBASE.Utility;

namespace e_maktab.Controllers.Admin;

[Route("api/[controller]/[action]")]
[ApiController]
public class RoleController : ControllerBase
{

    private readonly IRoleService _service;
    public RoleController(IRoleService service)
    {
        _service = service;
    }
    [HttpGet]
    public IActionResult GetList([FromQuery] RoleListSortFilterOptions filter)
    {
        try
        {
            return Ok( _service.GetList(filter));
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
    public async Task<IActionResult> Create([FromBody] CreateRoleDto model)
    {
        try
        {
            return Ok(await _service.Create(model));
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
    public async Task<IActionResult> Update([FromBody] UpdateRoleDto dto)
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
