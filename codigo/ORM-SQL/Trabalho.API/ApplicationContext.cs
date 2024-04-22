using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Trabalho.API;

namespace Trabalho.API
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; } = null!;
        public DbSet<Cliente> Clientes { get; set; } = null!;
        public DbSet<Reserva> Reservas { get; set; } = null!;
    }
}
