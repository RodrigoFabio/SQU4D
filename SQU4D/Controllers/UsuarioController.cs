using Microsoft.AspNetCore.Mvc;
using SQU4D.Application.Service;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using SQU4D.Domain.Interfaces.Service;

namespace SQU4D.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase
{
    //UsuarioAppService usuarioAppService = new UsuarioAppService();
    private UsuarioAppService _userService;

    public UsuarioController(UsuarioAppService userService)
    {
        _userService = userService;
    }

    
    [HttpPost("validar")]
    public IActionResult ValidaUsuario([FromBody] LoginUsuarioDTO usuarioLogin)
    {   //colocar regex email
        var usuario = _userService.ValidarCredenciais(usuarioLogin);
        if (!usuario)
        {
            return BadRequest();
        }
        return Ok(new { Success = true });
    }

    [HttpPost("cadastrar")]
    public IActionResult CadastraUsuario([FromBody] CadastroUsuarioDTO usuarioCadastro)
    {
        var cadastrado = _userService.CadastrarNovoUsuario(usuarioCadastro);
        if (cadastrado)
        {
            return Ok();
        }
        return BadRequest();
    }
}
