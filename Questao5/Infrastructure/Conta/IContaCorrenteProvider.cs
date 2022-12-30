using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Conta
{
    public interface IContaCorrenteProvider
    {
        Task<IEnumerable<ContaCorrente>> Get();
    }
}
