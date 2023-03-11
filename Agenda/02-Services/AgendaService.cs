using Agenda._02_Services.Interface;
using Agenda._03_Repositories;
using Agenda._03_Repositories.Interface;
using Agenda._04_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace Agenda._02_Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;
        private readonly ITarefaService _tarefaService;

        public AgendaService(IAgendaRepository agendaRepository,
            ITarefaService tarefaService)
        {
            _agendaRepository = agendaRepository;
            _tarefaService = tarefaService;
        }

        public async Task<List<AgendaModel>> GetAllAgendas()
        {
            var agendas = new List<AgendaModel>();
            var listAgendas = new List<AgendaModel>();
            var listTarefas = new List<TarefaModel>();
            var agendaRepository = await _agendaRepository.GetAllAgendas();
            var tarefas = await _tarefaService.GetAllTarefas();
            

            foreach (var item in agendaRepository)
            {
                listTarefas = tarefas.Where(x => x.AgendaId == item.Id).ToList();
                var agenda = new AgendaModel()
                {
                    Id = item.Id,
                    NomeAgenda = item.NomeAgenda,
                    CriadorAgenda = item.CriadorAgenda,
                    DataCriacao = item.DataCriacao,
                    Tarefas = listTarefas
                };
                listAgendas.Add(agenda);
            }
            return listAgendas;
        }

        public async Task<int> NovaAgenda(NovaAgendaModel model)
        {
            var novaAgenda = new NovaAgendaModel()
            {
                NomeAgenda = model.NomeAgenda,
                CriadorAgenda = model.CriadorAgenda,
            };

            var response = await _agendaRepository.NovaAgenda(novaAgenda);

            return response;
        }
    }
}
