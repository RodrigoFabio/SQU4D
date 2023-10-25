using FluentValidation.Results;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using SQU4D.Data.Repository;
using SQU4D.Domain.Interfaces.Service;

namespace SQU4D.Domain.Application.Service;

public class UsuarioAppService
{
    private readonly UsuarioRepository _userRepository;

    public UsuarioAppService(UsuarioRepository usuarioRepository)
    {

        _userRepository = usuarioRepository;
    }

    public bool ValidarCredenciais(LoginUsuarioDTO loginUsuario)
    {
        if (loginUsuario != null || loginUsuario.Email != "")
        {
            var result = _userRepository.ValidaCredenciaisUsuario(loginUsuario);
            if (result.IsValid) { return true; }
        }
        return false;
    }

    public bool CadastrarNovoUsuario(CadastroUsuarioDTO novoUsuario)
    {
        novoUsuario.Senha = CriptografarSenha(novoUsuario.Senha);
        var result = _userRepository.CadastraNovoUsuario(novoUsuario);
        if (!result.IsValid) { return true; }
        return false;
    }

    public string CriptografarSenha(string senha)
    {
        var senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(senha);
        return senhaCriptografada;
    }


}
