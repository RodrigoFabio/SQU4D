using AutoMapper;
using SQU4D.Data.Context;
using SQU4D.Data.Models;

namespace SQU4D.Data.Repository;

public class EncaminhamentoRepository
{
    private Squ4dContext _context;
    private IMapper _mapper;
    public EncaminhamentoRepository(Squ4dContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public bool AdicionaEncaminhamento(Encaminhamento encaminhamento)
    {
        _context.Encaminhamentos.Add(encaminhamento);
        _context.SaveChanges();
        return true;
    }


}
