using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SQU4D.Data.Models;

namespace SQU4D.Data.Context;

public class Squ4dContext : DbContext
{
    public Squ4dContext(DbContextOptions<Squ4dContext> opts)
        : base(opts)
    {
    }
        public DbSet<Usuario> Usuarios{ get; set; }
        public DbSet<Alert> Alerts { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Encaminhamento> Encaminhamentos { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
}
