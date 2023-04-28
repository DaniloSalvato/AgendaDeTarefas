using System;

namespace Agenda._04_Models
{
    public class NovaTarefaModel
    {
        public string Descricao { get; set; }
        public DateTime DataTarefa { get; set; }
        public bool Status { get; set; }
        public int AgendaId { get; set; }
    }
}
