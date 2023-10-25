using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using SQU4D.Domain.Application.Service;
using System.Text.Json;

namespace SQU4D.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertController: ControllerBase
{
    private readonly AlertAppService _alertService;
    public AlertController( AlertAppService alertService)
    {
        
        _alertService = alertService;
    }

    [HttpGet("BuscaAlertas")]
    public IActionResult BuscaAlertas([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        var alerts = _alertService.BuscaAlertas(skip, take).ToArray();
        var json = JsonSerializer.Serialize(alerts);
        return Content(json, "application/json");
    }

    [HttpGet("Filtro")]
    public async Task<IActionResult> FiltraAlertas([FromBody] FiltroAlertaDTO itensFiltro, [FromQuery] int page = 1, [FromQuery] int take = 10)
    {
        var alerts = await _alertService.FiltraAlertas(itensFiltro, page, take); 
        var json = JsonSerializer.Serialize(alerts);    
        return Content(json, "application/json");
    }

    [HttpPost("json")]
    public IActionResult PostJson([FromBody] JsonElement json)
    {

        if (json.ToString() != null)
        {
            _alertService.ConvertJson(json);
            return Ok();
        }
        return BadRequest();
    }

   
}
