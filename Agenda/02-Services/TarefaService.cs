using Agenda._02_Services.Interface;
using Agenda._03_Repositories;
using Agenda._03_Repositories.Interface;
using Agenda._04_Models;
using System;
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

        public async Task<int> NovaTarefa(NovaTarefaModel model)
        {          
            var novaTarefa = new NovaTarefaModel()
            {
                Descricao = model.Descricao,
                DataTarefa = model.DataTarefa,
                Status = model.Status,
                AgendaId = model.AgendaId,
            };
            return await _tarefaRepository.NovaTarefa(novaTarefa);
        }
    }
}
