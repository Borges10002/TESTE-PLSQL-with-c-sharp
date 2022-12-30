using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Conta
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public ContaCorrenteRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task Create(ContaCorrente contaCorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            await connection.ExecuteAsync("INSERT INTO contacorrente (idcontacorrente, numero, nome, ativo)" + "VALUES (@IdContaCorrente, @Numero, @Nome, @Ativo);", contaCorrente);

        }
    }
}
