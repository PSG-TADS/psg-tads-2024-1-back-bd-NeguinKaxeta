using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ORM_SQL
{
    internal class Program
    {
        public class Veiculo
        {
            [Key]
            public int Id { get; set; }
            public string? Modelo { get; set; }
            public string? Marca { get; set; }
            public int AnoFabricacao { get; set; }
            // Outros atributos, propriedades e relacionamentos...
        }

        public class Cliente
        {
            [Key]
            public int Id { get; set; }
            public string? Nome { get; set; }
            public string? Email { get; set; }
            // Outros atributos, propriedades e relacionamentos...
        }

        public class Reserva
        {
            [Key]
            public int Id { get; set; }
            public int VeiculoId { get; set; }
            [ForeignKey("VeiculoId")]
            public Veiculo? Veiculo { get; set; }
            public int ClienteId { get; set; }
            [ForeignKey("ClinteId")]
            public Cliente? Cliente { get; set; }
            public DateTime DataInicio { get; set; }
            public DateTime DataFim { get; set; }
        }

        

        public class ApplicationDbContext : DbContext
        {
            public DbSet<Veiculo> Veiculos { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Reserva> Reservas { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                // Configure a conexão com o banco de dados aqui
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS01;Database=Trabalho;Trusted_Connection=True;TrustServerCertificate=true");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }
}
