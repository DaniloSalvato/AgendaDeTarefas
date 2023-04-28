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
    public class AgendaRepository : IAgendaRepository
    {
        private readonly IConfiguration _configuration;

        public AgendaRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<AgendaModel>> GetAllAgendas()
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" SELECT * FROM agenda WITH (NOLOCK) WHERE ativo = 1 ORDER BY 1 ASC ";
                var result = await conn.QueryAsync<AgendaModel>(sql.ToString());
                return result?.Count() > 0 ? result.ToList() : new List<AgendaModel>();
            }
        }

        public async Task<AgendaModel> GetAgenda(AgendaModel model)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" SELECT * FROM agenda WITH (NOLOCK) WHERE Id = @Id";
                var result = await conn.QueryAsync<AgendaModel>(sql.ToString());
                return result?.Count() > 0 ? result.FirstOrDefault() : new AgendaModel();
            }
        }

        public async Task<AgendaModel> GetAgendaById(int id)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" SELECT * FROM agenda WITH (NOLOCK) WHERE Id = @id";
                var result = await conn.QueryAsync<AgendaModel>(sql.ToString(), new { id });
                return result?.Count() > 0 ? result.FirstOrDefault() : new AgendaModel();
            }
        }

        public async Task<int> NovaAgenda(NovaAgendaModel model)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" INSERT INTO [agenda] (
                                        [NomeAgenda], 
                                        [CriadorAgenda],
                                        [DataCriacao],
                                        [Ativo]
                                       ) VALUES (
                                        @NomeAgenda,
                                        @CriadorAgenda,
                                        GETDATE(),
                                        1
                                       );SELECT CAST(SCOPE_IDENTITY() AS INT) ";
                var result = await conn.QueryAsync<int>(sql.ToString(), model);
                return result?.Count() > 0 ? result.FirstOrDefault() : new int();
            }
        }

        public async Task<int> AtualizaAgenda(AtualizarAgendaModel model)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" UPDATE [agenda] SET NomeAgenda = @NomeAgenda WHERE Id = @Id
                              SELECT @@ROWCOUNT AS [RowsAffected]";
                var result = await conn.QueryAsync<int>(sql.ToString(), model);
                return result?.Count() > 0 ? result.FirstOrDefault() : new int();
            }
        }

        public async Task<int> DesabilitaAgendas(DesabilitaAgendaModel model)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" UPDATE [agenda] SET Ativo = @Ativo WHERE Id = @Id
                              SELECT @@ROWCOUNT AS [RowsAffected]";
                var result = await conn.QueryAsync<int>(sql.ToString(), model);
                return result?.Count() > 0 ? result.FirstOrDefault() : new int();
            }
        }
    }
}
