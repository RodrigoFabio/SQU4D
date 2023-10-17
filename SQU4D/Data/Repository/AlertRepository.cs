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
}
