using AgendaApp.Data.Entities.Enums;

namespace AgendaApp.Data.Entities
{
    /// <summary>
    /// Modelo de entidade para tarefa
    /// </summary>
    public class Tarefa
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public PrioridadeTarefa? Prioridade { get; set; }
        public DateTime? DataHoraCadastro { get; set; }
        public DateTime? DataHoraUltimaAtualizacao { get; set; }
        public int? Status { get; set; }
    }
}
