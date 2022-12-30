using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Movimento
{
    public interface IMovimentoProvider
    {
        Task<IEnumerable<MovimentoConta>> Get(string idcontacorrente);
    }
}
