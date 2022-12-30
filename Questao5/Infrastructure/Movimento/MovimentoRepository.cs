using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Movimento
{
    public class MovimentoRepository : IMovimentoRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentoRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(MovimentoConta movimento)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor)" + "VALUES (@IdMovimento, @IdContaCorrente, @DataMovimento, @TipoMovimento, @Valor);", movimento);

        }
    }
}
