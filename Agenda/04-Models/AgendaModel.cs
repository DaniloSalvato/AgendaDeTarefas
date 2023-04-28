using System;
using System.Collections.Generic;

namespace Agenda._04_Models
{
    public class AgendaModel
    {
        public int Id { get; set; }
        public string NomeAgenda { get; set; }
        public string CriadorAgenda { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<TarefaModel> Tarefas { get; set; }
    }
}
