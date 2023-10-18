using AutoMapper;
using SQU4D.Data.Context;
using SQU4D.Data.Models;

namespace SQU4D.Data.Repository;

public class AlertRepository
{
    private Squ4dContext _context;
    private IMapper _mapper;
    public AlertRepository(Squ4dContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public bool AdicionaAlert(AlertDTO novoAlertDTO)
    {
        Alert alert = _mapper.Map<Alert>(novoAlertDTO); 
        _context.Alerts.Add(alert);
        _context.SaveChanges();
        return true;
    }

    public IEnumerable<Alert> BuscaAlertas(int skip, int take)
    {
        return _context.Alerts.Skip(skip).Take(take);
    }

    public IEnumerable<Alert> FiltraAlertas(string cor, string severidade, DateTime data)
    {
        return _context.Alerts.Where(x => x.Color == cor && x.Severity == severidade && x.Time == data);
    }

    public Alert GetAlert(int id) { return _context.Alerts.FirstOrDefault(x => x.Id == id); }
}
