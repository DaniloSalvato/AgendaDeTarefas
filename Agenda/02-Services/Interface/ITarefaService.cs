using Agenda._04_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda._02_Services.Interface
{
    public interface ITarefaService
    {
        Task<List<TarefaModel>> GetAllTarefas(int agendaId);
        Task<int> NovaTarefa(NovaTarefaModel model);
        Task<int> AtualizarTarefa(AtualizarTarefaModel model);
    }
}
