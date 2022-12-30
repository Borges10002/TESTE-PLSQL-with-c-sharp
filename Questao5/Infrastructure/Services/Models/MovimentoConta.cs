using System.ComponentModel.DataAnnotations;

namespace Questao5.Infrastructure.Services.Models
{
    public class MovimentoConta
    {
        [Key]
        [Required]
        public string IdMovimento { get; set; }
        public string IdContaCorrente { get; set; }
 
        public string DataMovimento { get; set; }
        public string TipoMovimento { get; set; }
        public decimal Valor { get; set; }

        public decimal Disponivel { get; set; }

    }
}
