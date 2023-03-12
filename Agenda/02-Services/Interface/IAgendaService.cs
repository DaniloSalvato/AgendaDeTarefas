using Agenda._04_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda._02_Services.Interface
{
    public interface IAgendaService
    {
        Task<List<AgendaModel>> GetAllAgendas();
        Task<AgendaModel> GetAgenda(int agendaId);
        Task<int> NovaAgenda(NovaAgendaModel model);
        Task<int> AtualizarAgenda(AtualizarAgendaModel model);
        Task<int> DesabilitaAgendas(DesabilitaAgendaModel model);
    }
}
