using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Idempotencia
{
    public class IdempotenciaProvider : IIdempotenciaProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public IdempotenciaProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<IdempotenciaConta>> Get()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<IdempotenciaConta>("SELECT * FROM idempotencia;");
        }
    }
}
