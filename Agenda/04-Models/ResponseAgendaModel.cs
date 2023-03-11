using System;
using System.Collections.Generic;

namespace Agenda._04_Models
{
    public class ResponseAgendaModel
    {
        public List<AgendaModel> Agendas { get; set; }  
        public List<TarefaModel> Tarefas { get; set; }  
    }
}
