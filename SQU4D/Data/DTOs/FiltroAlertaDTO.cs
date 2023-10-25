namespace SQU4D.Data.DTOs;

public class FiltroAlertaDTO
{

    public string? Color { get; set; }
    public string Cliente { get; set; }
    public string? Severity { get; set; }

    public DateTime? DataInicial { get; set; }
    public DateTime? DataFinal { get; set; };

}
