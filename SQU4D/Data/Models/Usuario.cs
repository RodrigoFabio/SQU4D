using System.ComponentModel.DataAnnotations;

namespace SQU4D.Data.Models;

public class Usuario
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nome { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string CNPJ { get; set; }
    [Required]
    public string Senha { get; set; }
}
