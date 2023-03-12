using System;

namespace Agenda._04_Models
{
    public class ResponseTarefaModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public DateTime DataTarefa { get; set; }
        public string StatusTarefa { get; set; }
        public int AgendaId { get; set; }
    }
}
