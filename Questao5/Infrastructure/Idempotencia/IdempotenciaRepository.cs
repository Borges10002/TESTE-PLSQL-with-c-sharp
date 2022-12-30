using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Idempotencia
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public IdempotenciaRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(IdempotenciaConta idempotencia)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado)" + "VALUES (@Chave_Idempotencia, @Requisicao, @Resultado);", idempotencia);

        }
    }
}
