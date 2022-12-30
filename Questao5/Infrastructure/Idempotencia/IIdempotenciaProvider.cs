using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Idempotencia
{
    public interface IIdempotenciaProvider
    {
        Task<IEnumerable<IdempotenciaConta>> Get();
    }
}
