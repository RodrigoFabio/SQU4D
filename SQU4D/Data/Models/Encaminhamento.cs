using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SQU4D.Data.Models;

[Table("Encaminhamento")]
public class Encaminhamento
{
    [Key]
    public int IdEncaminhamento { get; set; }
    [ForeignKey("AlertId")]
    public int AlertId { get; set; }
    public virtual Alert? Alert { get; set; }

    [ForeignKey("UsuarioId")]
    public int UsuarioId { get; set; }
    public virtual Usuario? Usuario { get; set; }
    public string? Motivo { get; set; }
    public int IdEmpresa { get; set; }
    public bool? EncaminhamentoAtivo { get; set; }
    public DateTime? DataInclusao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public string? UsuarioInc { get; set; }
    public string? UsuarioAlt { get; set; }
    public int? OrigemRetorno { get; set; }
}
