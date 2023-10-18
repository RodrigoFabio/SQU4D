using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SQU4D.Application.Service;
using SQU4D.Data.Models;
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
    public IActionResult BuscaAlertas([FromQuery] int skip = 0, [FromQuery] int take = 30)
    {
        var alerts = _alertService.BuscaAlertas(skip, take).ToArray();
        var json = JsonSerializer.Serialize(alerts);
        return Content(json, "application/json");
    }

    [HttpGet("Filtro")]
    public IActionResult FiltraAlertas([FromQuery] string cor, [FromQuery] string severidade, [FromQuery] DateTime data)
    {
        var alerts = _alertService.FiltraAlertas(cor, severidade, data); 
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

    [HttpPost("Tratativa")]
    public IActionResult PostTratativa([FromBody] int AlertaId)
    {

        
            return Ok();
       
    }
}
