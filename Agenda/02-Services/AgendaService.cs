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
                foreach (var tarefaAtiva in listTarefas)    
                {
                    if (tarefaAtiva.DataTarefa > DateTime.Now)
                    {
                        tarefaAtiva.StatusTarefa = "Em Aberto";
                    }
                    else
                    {
                        tarefaAtiva.StatusTarefa = "Em Atraso";
                    }
                }
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

        public async Task<AgendaModel> GetAgenda(int agendaId)
        {
            var agenda = await _agendaRepository.GetAgendaById(agendaId);
            var tarefas = await _tarefaService.GetAllTarefas();

            var listTarefas = tarefas.Where(x => x.AgendaId == agenda.Id).ToList();
            foreach (var tarefaAtiva in listTarefas)
            {
                if (tarefaAtiva.DataTarefa > DateTime.Now)
                {
                    tarefaAtiva.StatusTarefa = "Em Aberto";
                }
                else
                {
                    tarefaAtiva.StatusTarefa = "Em Atraso";
                }
            }
            var agendaCompleta = new AgendaModel()
            {
                Id = agenda.Id,
                NomeAgenda = agenda.NomeAgenda,
                CriadorAgenda = agenda.CriadorAgenda,
                DataCriacao = agenda.DataCriacao,
                Tarefas = listTarefas
            };
            return agendaCompleta;
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

        public async Task<int> AtualizarAgenda(AtualizarAgendaModel model)
        {
            var atualizaAgenda = new AtualizarAgendaModel()
            {
                Id = model.Id,
                NomeAgenda = model.NomeAgenda,
            };

            return await _agendaRepository.AtualizaAgenda(atualizaAgenda);
        }

        public async Task<int> DesabilitaAgendas(DesabilitaAgendaModel model)
        {
            var desabilitaAgenda = new DesabilitaAgendaModel()
            {
                Id = model.Id,
                Ativo = model.Ativo,
            };         

            return await _agendaRepository.DesabilitaAgendas(desabilitaAgenda);
        }
    }
}
