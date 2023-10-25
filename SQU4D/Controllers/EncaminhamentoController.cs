using Microsoft.AspNetCore.Mvc;
using SQU4D.Domain.Application.Service;

namespace SQU4D.Controllers;


[ApiController]
[Route("[controller]")]
public class EncaminhamentoController : ControllerBase
{
    private EncaminhamentoService _encaminhamentoService;

    public EncaminhamentoController(EncaminhamentoService encaminhamentoService)
    {
        _encaminhamentoService = encaminhamentoService;
    }

    [HttpPost("Tratativa")]
    public async Task<IActionResult> PostTratativa([FromBody] int AlertaId)
    {
        if(await _encaminhamentoService.PostSyonet(AlertaId)){
                  return Ok();
        }
        return BadRequest();
    }

}
