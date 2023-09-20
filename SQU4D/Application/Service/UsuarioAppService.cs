using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using SQU4D.Domain.Interfaces.Service;

namespace SQU4D.Application.Service;

public class UsuarioAppService : IUsuarioService
{
    public bool ValidarCredenciais(LoginUsuarioDTO loginUsuario)
    {
        //var usuario = usuarios.Where(usuario => usuario.CNPJ == cnpj).FirstOrDefault();
        //implementação do metodo
        return true;
    }

    public bool CadastrarNovoUsuario(CadastroUsuarioDTO novoUsuario)
    {
        //implementação do metodo
        //save changes
        return true;
    }

    public string CriptografarSenha(string senha)
    {
        var senhaCriptografada = BCrypt.Net.BCrypt.HashPassword(senha);
        return senhaCriptografada;
    }


}
