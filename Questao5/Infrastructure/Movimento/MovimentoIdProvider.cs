using Dapper;
using Microsoft.Data.Sqlite;
using Questao5.Infrastructure.Services.Models;
using Questao5.Infrastructure.Sqlite;

namespace Questao5.Infrastructure.Movimento
{
    public class MovimentoIdProvider : IMovimentoIdProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public MovimentoIdProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        //B6BAFC09-6967-ED11-A567-055DFA4A16C9
        public async Task<IEnumerable<MovimentoContaDisponive>> GetId(string idcontacorrente)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<MovimentoContaDisponive>(" SELECT tab.numero, tab.nome, DATETIME('now') as data, SUM(tab.credito - tab.debito)as vlsaldo " + 
                                                                       " FROM (" +
                                                                       "   SELECT movimento.idContaCorrente, " +
                                                                              " SUM(valor)as credito, " +
                                                                              " 0 as debito, " +
                                                                              "contacorrente.numero, " +
                                                                              "contacorrente.nome " +

                                                                              " FROM movimento, contacorrente " +
                                                                              " WHERE movimento.idcontacorrente = contacorrente.idcontacorrente " +
                                                                              " and movimento.tipomovimento = 'C' " +
                                                                              " and movimento.idcontacorrente = @idcontacorrente " +

                                                                              "UNION ALL" +

                                                                         " SELECT movimento.idContaCorrente, " +
                                                                              " 0 as credito,  " +
                                                                              " SUM(valor)as debito, " +
                                                                              "contacorrente.numero, " +
                                                                              "contacorrente.nome " +

                                                                              " FROM movimento, contacorrente " +
                                                                              " WHERE movimento.idcontacorrente = contacorrente.idcontacorrente " +
                                                                              " and movimento.tipomovimento = 'D' " +

                                                                              " and movimento.idcontacorrente = @idcontacorrente" +

                                                                        ") tab" +

                                                                        "; " 

                                                                              , new
                                                                                {
                                                                                    idcontacorrente
                                                                                });
        }
    }
}
