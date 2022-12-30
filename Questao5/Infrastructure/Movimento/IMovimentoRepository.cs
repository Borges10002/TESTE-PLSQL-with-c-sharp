using Questao5.Infrastructure.Services.Models;

namespace Questao5.Infrastructure.Movimento
{
    public interface IMovimentoRepository
    {
        Task Create(MovimentoConta movimento);
    }
}