using Agenda._03_Repositories.Interface;
using Agenda._04_Models;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
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
                var sql = $@" SELECT * FROM agenda AS A WITH (NOLOCK) ORDER BY 1 ASC ";
                var result = await conn.QueryAsync<AgendaModel>(sql.ToString());
                return result?.Count() > 0 ? result.ToList() : new List<AgendaModel>();
            }
        }

        public async Task<int> NovaAgenda(NovaAgendaModel model)
        {
            using (var conn = new SqlConnection(_configuration.GetSection("ConnectionStrings").GetSection("STRING_CONECTION").Value))
            {
                var sql = $@" INSERT INTO [agenda] (
                                        [NomeAgenda], 
                                        [CriadorAgenda],
                                        [DataCriacao]
                                       ) VALUES (
                                        @NomeAgenda,
                                        @CriadorAgenda,
                                        GETDATE()
                                       );SELECT CAST(SCOPE_IDENTITY() AS INT) ";
                var result = await conn.QueryAsync<int>(sql.ToString(), model);
                return result?.Count() > 0 ? result.FirstOrDefault() : new int();
            }
        }
    }
}
