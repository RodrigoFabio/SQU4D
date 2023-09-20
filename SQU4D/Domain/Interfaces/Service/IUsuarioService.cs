using SQU4D.Data.DTOs;

namespace SQU4D.Domain.Interfaces.Service;

public interface IUsuarioService
{
    public bool ValidarCredenciais(LoginUsuarioDTO loginUsuario);

    public bool CadastrarNovoUsuario(CadastroUsuarioDTO novoUsuario);

    public string CriptografarSenha(string senha);
}
