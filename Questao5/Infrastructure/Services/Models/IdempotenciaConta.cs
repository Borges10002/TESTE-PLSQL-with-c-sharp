using System.ComponentModel.DataAnnotations;

namespace Questao5.Infrastructure.Services.Models
{
    public class IdempotenciaConta
    {
        [Key]
        [Required]
        public string Chave_Idempotencia { get; set; }
        public string Requisicao { get; set; }
        public string Resultado { get; set; }
    }
}
