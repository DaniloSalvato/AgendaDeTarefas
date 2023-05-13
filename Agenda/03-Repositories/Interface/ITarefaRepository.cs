using Agenda._04_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda._03_Repositories.Interface
{
    public interface ITarefaRepository
    {
        Task<List<TarefaModel>> GetAllTarefas(int agendaId);
        Task<int> NovaTarefa(NovaTarefaModel model);
        Task<int> AtualizarTarefa(AtualizarTarefaModel model);
    }
}
