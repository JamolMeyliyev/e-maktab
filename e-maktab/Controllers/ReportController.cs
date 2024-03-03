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
}
