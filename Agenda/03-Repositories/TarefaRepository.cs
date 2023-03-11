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

        public async Task<List<TarefaModel>> GetAllTarefas()
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" SELECT [Id],
	                          [Descricao],
	                          [DataTarefa],
	                          [Status],
                              [AgendaId]
                              FROM tarefa WITH (NOLOCK) ORDER BY 1 ASC ";
                var result = await conn.QueryAsync<TarefaModel>(sql.ToString());
                return result?.Count() > 0 ? result.ToList() : new List<TarefaModel>();
            }
        }
    }
}
