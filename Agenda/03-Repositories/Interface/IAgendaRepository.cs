using Agenda._04_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda._03_Repositories.Interface
{
    public interface IAgendaRepository
    {
        Task<List<AgendaModel>> GetAllAgendas();
        Task<int> NovaAgenda(NovaAgendaModel model);
    }
}
