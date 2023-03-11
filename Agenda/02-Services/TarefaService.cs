using Agenda._02_Services.Interface;
using Agenda._03_Repositories;
using Agenda._03_Repositories.Interface;
using Agenda._04_Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Agenda._02_Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<List<TarefaModel>> GetAllTarefas() => await _tarefaRepository.GetAllTarefas();       
    }
}
