using AutoMapper;
using SQU4D.Data.Context;
using SQU4D.Data.Models;

namespace SQU4D.Data.Repository;

public class VeiculoRepository
{

    private Squ4dContext _context;
    private IMapper _mapper;
    public VeiculoRepository(Squ4dContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public Veiculo? RecuperaVeiculoById(int VeiculoId)
    {
        return _context.Veiculos.Where(v => v.Id == VeiculoId).FirstOrDefault();
    }
}
