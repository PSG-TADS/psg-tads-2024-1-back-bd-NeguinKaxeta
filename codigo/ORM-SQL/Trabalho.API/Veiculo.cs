using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Trabalho.API
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
}
