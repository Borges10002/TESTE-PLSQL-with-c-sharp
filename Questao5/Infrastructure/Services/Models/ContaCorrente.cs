using System.ComponentModel.DataAnnotations;
using Xunit.Sdk;

namespace Questao5.Infrastructure.Services.Models
{
    public class ContaCorrente
    {
        [Key]
        [Required]
        public string IdContaCorrente { get; set; }

        [Required(ErrorMessage = "Numero da conta é obrigatorio")]
        public int Numero { get; set; }

        [Required(ErrorMessage = "O Nome é obrigatório")]
        [StringLength(100, ErrorMessage = "O tamanho do Nome não pode exceder 100 caracteres")]
        public string Nome { get; set; }
        public int Ativo { get; set; }
    }
}
