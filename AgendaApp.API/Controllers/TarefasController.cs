using AgendaApp.API.Models;
using AgendaApp.Data.Entities;
using AgendaApp.Data.Entities.Enums;
using AgendaApp.Data.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        //atributo
        private readonly IMapper _mapper;

        //método construtor para inicializar o AutoMapper
        //injeção de dependência (inicialização automática)
        public TarefasController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Serviço da API para cadastro de tarefas
        /// </summary>
        /// 

        [HttpPost]
        [ProducesResponseType(typeof(CriarTarefaResponseModel), 201)]
        public IActionResult Post(CriarTarefaRequestModel model)
        {
            try
            {
                //copiando os dados do objeto 'model' para 'tarefa'
                var tarefa = _mapper.Map<Tarefa>(model);

                //complementando as informações da entidade 'tarefa'
                tarefa.Id = Guid.NewGuid();
                tarefa.DataHoraCadastro = DateTime.Now;
                tarefa.DataHoraUltimaAtualizacao = DateTime.Now;
                tarefa.Status = 1;

                //gravando no banco de dados
                var tarefaRepository = new TarefaRepository();
                tarefaRepository.Add(tarefa);

                //copiando os dados do objeto 'tarefa' para 'response'
                var response = _mapper.Map<CriarTarefaResponseModel>(tarefa);

                return StatusCode(201, response);
            }
            catch(Exception e)
            {
                return StatusCode(500, new { message = "Ocorreu um erro ao processar a solicitação"});
            }
        }

        /// <summary>
        /// Serviço da API para edição de tarefas
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(EditarTarefaResponseModel), 200)]
        public IActionResult Put(EditarTarefaRequestModel model)
        {
            try
            {
                //buscar a tarefa no banco de dados através do ID
                var tarefaRepository = new TarefaRepository();
                var tarefa = tarefaRepository.GetById(model.Id.Value);

                //verificar se a tarefa foi encontrada
                if(tarefa != null)
                {
                    //modificar os dados da tarefa
                    tarefa.Nome = model.Nome;
                    tarefa.Descricao = model.Descricao;
                    tarefa.DataHora = model.DataHora;
                    tarefa.Prioridade = (PrioridadeTarefa) model.Prioridade;
                    tarefa.DataHoraUltimaAtualizacao = DateTime.Now;
                    tarefa.Status = model.Status;

                    //atualizar no banco de dados
                    tarefaRepository.Update(tarefa);

                    //copiando os dados do objeto 'tarefa' para 'response'
                    var response = _mapper.Map<EditarTarefaResponseModel>(tarefa);

                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(400, new { message = "O ID da tarefa é inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Serviço da API para exclusão de tarefas
        /// </summary>
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ExcluirTarefaResponseModel), 200)]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //buscar a tarefa no banco de dados através do ID
                var tarefaRepository = new TarefaRepository();
                var tarefa = tarefaRepository.GetById(id);

                //verificar se a tarefa foi encontrada
                if(tarefa != null)
                {
                    //excluindo a tarefa
                    tarefaRepository.Delete(tarefa);

                    //copiando os dados do objeto 'tarefa' para o objeto 'response'
                    var response = _mapper.Map<ExcluirTarefaResponseModel>(tarefa);
                    response.DataHoraExclusao = DateTime.Now;

                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(400, new { message = "O ID da tarefa é inválido." });
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<ConsultarTarefaResponseModel>), 200)]
        public IActionResult Get(DateTime? dataInicio, DateTime? dataFim, string? nome)
        {
            try
            {
                var tarefaRepository = new TarefaRepository();
                var tarefa = tarefaRepository.Get(dataInicio, dataFim, nome);

                var response = _mapper.Map<List<ConsultarTarefaResponseModel>>(tarefa);

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        /// <summary>
        /// Serviço da API para consultar 1 tarefa baseado no ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ConsultarTarefaResponseModel), 200)]
        public IActionResult GetById(Guid id)
        {
            try
            {
                //consultando a tarefa no banco de dados através do ID
                var tarefaRepository = new TarefaRepository();
                var tarefa = tarefaRepository.GetById(id);

                //verificar se a tarefa foi encontrada
                if(tarefa != null)
                {
                    //copiar os dados do objeto 'tarefa' para 'response'
                    var response = _mapper.Map<ConsultarTarefaResponseModel>(tarefa);

                    return StatusCode(200, response);
                }
                else
                {
                    return StatusCode(204); //NoContent
                }
            }
            catch(Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }
    }
}
