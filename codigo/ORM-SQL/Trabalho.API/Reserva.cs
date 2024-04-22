using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
namespace Trabalho.API
{
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
}
