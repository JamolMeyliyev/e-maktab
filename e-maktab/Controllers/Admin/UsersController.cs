using e_maktab.Attributes;
using e_maktab.BizLogicLayer.Models;
using e_maktab.BizLogicLayer.Services;
using e_maktab.Core.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_maktab.Controllers.Admin;

[Route("api/[controller]/[action]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _service;
    public UsersController(IUserService service)
    {
        _service = service;
    }
    [HttpGet]
    [Authorize(moduleCodes: ModuleCode.UserView)]
    public async Task<IActionResult> GetList(UserListSortFilterOptions options)
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
    [Authorize(moduleCodes:ModuleCode.UserCreate)]
    public async Task<IActionResult> Create(CreateUserDto dto)
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
}
