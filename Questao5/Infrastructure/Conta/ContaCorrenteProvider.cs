using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Conta
{
    public class ContaCorrenteProvider : IContaCorrenteProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrenteProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<ContaCorrente>> Get()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<ContaCorrente>("SELECT * FROM contacorrente;");
        }
    }
}
