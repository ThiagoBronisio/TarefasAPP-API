using AgendaApp.API.Models;
using AgendaApp.Data.Entities;
using AutoMapper;

namespace AgendaApp.API.Mappings
{
    /// <summary>
    /// Classe para configurar os mapeamentos do AutoMapper
    /// </summary>
    public class ProfileMap : Profile
    {
        /// <summary>
        /// Método construtor da classe
        /// </summary>
        public ProfileMap()
        {
            //DE / PARA -> CriarTarefaRequestModel / Tarefa
            CreateMap<CriarTarefaRequestModel, Tarefa>();

            //DE / PARA -> Tarefa / CriarTarefaResponseModel
            CreateMap<Tarefa, CriarTarefaResponseModel>();

            //DE / PARA -> Tarefa / EditarTarefaResponseModel
            CreateMap<Tarefa, EditarTarefaResponseModel>();

            //DE / PARA -> Tarefa / ExcluirTarefaResponseModel
            CreateMap<Tarefa, ExcluirTarefaResponseModel>();

            //DE / PARA -> Tarefa / ConsultarTarefaResponseModel
            CreateMap<Tarefa, ConsultarTarefaResponseModel>();
        }
    }
}
