namespace AgendaApp.API.Models
{
    /// <summary>
    /// Modelo de dados da resposta de exclusão de tarefa
    /// </summary>
    public class ExcluirTarefaResponseModel
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public DateTime? DataHora { get; set; }
        public int? Prioridade { get; set; }
        public DateTime? DataHoraExclusao { get; set; }
        public int? Status { get; set; }
    }
}
