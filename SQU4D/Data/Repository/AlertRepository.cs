using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SQU4D.Data.Context;
using SQU4D.Data.DTOs;
using SQU4D.Data.Models;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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

    public IEnumerable<Alert> BuscaAlertas(int? page, int take=10)
    {
        int numeroPagina = page ?? 1;
        return _context.Alerts.Skip((numeroPagina -1) * take).Take(take);
    }

    public  async Task<IEnumerable<Alert>> FiltraAlertas(FiltroAlertaDTO filtroAlertaDTO, int?page, int take=10)
    {
        int numeroPagina = page ?? 1;
        var filtro = _context.Alerts
                        .Include(a => a.Veiculo)
                        .ThenInclude(v => v.Cliente)
                        .AsNoTracking();

        Type dtoType = filtroAlertaDTO.GetType();
        PropertyInfo[] properties = dtoType.GetProperties();

        foreach (PropertyInfo property in properties)
        {
            string nome = property.Name;
            object valor = property.GetValue(filtroAlertaDTO);
            valor = valor.ToString;
             if (valor != null)
            {
                if (nome == "Color")
                {
                    filtro = filtro.Where(x => x.Color == valor);
                }else if(nome == "Severity")
                {
                    filtro = filtro.Where(x => x.Severity == valor);
                }else if(nome == "Cliente")
                {
                    filtro = filtro.Where(a => a.Veiculo != null && a.Veiculo.Cliente != null && a.Veiculo.Cliente.Nome.Contains(filtroAlertaDTO.Cliente));
                }
            }
        }

        if (filtroAlertaDTO.DataInicial.HasValue && filtroAlertaDTO.DataFinal.HasValue)
        {
            filtro = filtro.Where(a => a.Time.HasValue && a.Time.Value.Date >= filtroAlertaDTO.DataInicial.Value.Date && a.Time.Value.Date <= filtroAlertaDTO.DataFinal.Value.Date);
        }
        var alertas = await filtro.ToListAsync();
        return alertas;
    }

    public Alert GetAlert(int id) { return _context.Alerts.FirstOrDefault(x => x.Id == id); }
}
