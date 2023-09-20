using Microsoft.AspNetCore.Mvc;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using SQU4D.Domain.Interfaces.Service;

namespace SQU4D.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController: ControllerBase
{
    private readonly IUsuarioService _userService;

    public UsuarioController(IUsuarioService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public IActionResult ValidaUsuario([FromBody] LoginUsuarioDTO usuarioLogin)
    {
        var usuario = _userService.ValidarCredenciais(usuarioLogin);
        
        if(!usuario) {
            return BadRequest();
        }
        return Ok(new { Success = true});
    }

    [HttpPost]
    public IActionResult CadastraUsurio([FromBody] CadastroUsuarioDTO usuarioCadastro)
    {
        var cadastrado = _userService.CadastrarNovoUsuario(usuarioCadastro);
        if (cadastrado)
        {
            return Ok();
        }
        return BadRequest();
    }
}
