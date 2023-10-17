using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SQU4D.Data.Models;

public class Veiculo
{
    [Key]
    public string Id { get; set; }
    public string modelo { get; set; }
    [ForeignKey("ClienteId")]
    public int ClienteId { get; set; }
    public virtual Cliente? Cliente { get; set; }
    public string Chassi { get; set; }
  
}
