using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Models.Role;
using e_maktab.BizLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
            _service.AsSelectList();
            return Ok();
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
}
