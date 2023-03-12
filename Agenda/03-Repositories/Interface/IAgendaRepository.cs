using Agenda._04_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda._03_Repositories.Interface
{
    public interface IAgendaRepository
    {
        Task<List<AgendaModel>> GetAllAgendas();
        Task<AgendaModel> GetAgenda(AgendaModel model);
        Task<AgendaModel> GetAgendaById(int Id);
        Task<int> NovaAgenda(NovaAgendaModel model);
        Task<int> AtualizaAgenda(AtualizarAgendaModel model);
        Task<int> DesabilitaAgendas(DesabilitaAgendaModel model);
    }
}
