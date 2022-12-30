using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Idempotencia
{
    public interface IIdempotenciaRepository
    {
        Task Create(IdempotenciaConta idempotencia);
    }
}