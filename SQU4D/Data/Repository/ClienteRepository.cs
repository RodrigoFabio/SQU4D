using AutoMapper;
using SQU4D.Data.Context;
using SQU4D.Data.Models;

namespace SQU4D.Data.Repository;

public class ClienteRepository
{
    private Squ4dContext _context;

    public ClienteRepository(Squ4dContext context)
    {
        _context = context;
    }
    public void AdicionaCliente(Cliente cliente)
    {
        if (cliente != null)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }
    }

    public Cliente? BuscaClientePorId(int id)
    {
        return _context.Clientes.Where(c => c.Id == id).FirstOrDefault();
    }

    public IEnumerable<Cliente> BuscaTodosClientes()
    {
        return _context.Clientes.ToList();
    }
}
