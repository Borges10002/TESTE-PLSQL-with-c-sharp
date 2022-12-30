using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Movimento
{
    public class MovimentoProvider : IMovimentoProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentoProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<MovimentoConta>> Get(string idcontacorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            if(idcontacorrente.Length > 0)
            {
                return await connection.QueryAsync<MovimentoConta>("SELECT * FROM contacorrente where ativo = 1 and idcontacorrente = @idcontacorrente;"
                      , new
                      {
                          idcontacorrente
                      });              
            }
            else
            {
                return await connection.QueryAsync<MovimentoConta>("SELECT * FROM movimento;");
            }
           
        }


    }
}
