using Agenda._03_Repositories.Interface;
using Agenda._04_Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Agenda._03_Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly IConfiguration _configuration;

        public TarefaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<TarefaModel>> GetAllTarefas(int agendaId)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" SELECT [Id],
                              [Descricao],
                              [DataTarefa],
                              [Status],
                              [AgendaId]
                              FROM tarefa WITH (NOLOCK)
                              WHERE AgendaId = @agendaId	
                              ORDER BY 1 ASC ";
                var result = await conn.QueryAsync<TarefaModel>(sql.ToString(), new { agendaId });
                return result?.Count() > 0 ? result.ToList() : new List<TarefaModel>();
            }
        }

        public async Task<int> NovaTarefa(NovaTarefaModel model)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" INSERT INTO tarefa (
                                Descricao,
                                DataTarefa,
                                Status,
                                AgendaId )
                              VALUES (
                                @Descricao,
                                @DataTarefa,
                                @Status,
                                @AgendaId)
                                SELECT CAST(SCOPE_IDENTITY() AS INT)";
                var result = await conn.QueryAsync<int>(sql.ToString(), model);
                return result?.Count() > 0 ? result.FirstOrDefault() : new int();
            }
        }

        public async Task<int> AtualizarTarefa(AtualizarTarefaModel model)
        {

            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = @"UPDATE tarefa SET
                             Descricao = @descricao,
                             [Status] = @status
	                         WHERE AgendaId = @agendaId
	                         AND Id = @tarefaId ";
                var result = await conn.QueryAsync<int>(sql.ToString(), model);
                return result?.Count() > 0 ? result.FirstOrDefault() : new int();
            }
        }
    }
}
