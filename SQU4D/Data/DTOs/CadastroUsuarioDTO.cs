using System.ComponentModel.DataAnnotations;

namespace SQU4D.Data.DTOs;

public class CadastroUsuarioDTO
{
    public string Email { get; set; }

    public string Nome { get; set; }

    public string CNPJ { get; set; }

    public string Senha { get; set; }
}
