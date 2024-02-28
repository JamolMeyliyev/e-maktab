using e_maktab.BizLogicLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_maktab.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IAccountService _service;
    public AccountController(IAccountService service)
    {
        _service = service;
    }
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        try
        {
            return Ok(await _service.Login(dto));
        }
        catch(Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
