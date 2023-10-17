using System.ComponentModel.DataAnnotations;

namespace SQU4D.Data.Models;

public class Cliente
{
    [Key] 
    public int Id { get; set; }

    public string Nome { get; set; }
    
    public string Email { get; set; }
}
