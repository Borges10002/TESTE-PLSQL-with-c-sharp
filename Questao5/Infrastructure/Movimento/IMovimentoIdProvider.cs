using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Movimento
{
    public interface IMovimentoIdProvider
    {
        Task<IEnumerable<MovimentoContaDisponive>> GetId(string id);
    }
}
