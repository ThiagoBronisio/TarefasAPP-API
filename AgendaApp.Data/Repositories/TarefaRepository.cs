using AgendaApp.Data.Contexts;
using AgendaApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Data.Repositories
{
    /// <summary>
    /// Classe de repositório de dados para tarefa.
    /// </summary>
    public class TarefaRepository
    {
        /// <summary>
        /// Método para gravar uma tarefa no banco de dados
        /// </summary>
        public void Add(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Add(tarefa);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para atualizar uma tarefa no banco de dados
        /// </summary>
        public void Update(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Update(tarefa);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para excluir uma tarefa no banco de dados
        /// </summary>
        public void Delete(Tarefa tarefa)
        {
            using (var dataContext = new DataContext())
            {
                dataContext.Remove(tarefa);
                dataContext.SaveChanges();
            }
        }

        /// <summary>
        /// Método para consultar as tarefas por um periodo de datas
        /// </summary>
        public List<Tarefa> Get(DateTime dataInicio, DateTime dataFim)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Tarefa>()
                    .Where(t => t.DataHora >= dataInicio && t.DataHora <= dataFim)
                    .OrderByDescending(t => t.DataHora)
                    .ToList();
            }
        }

        /// <summary>
        /// Método para retornar 1 tarefa através do ID informado
        /// </summary>
        public Tarefa? GetById(Guid id)
        {
            using (var dataContext = new DataContext())
            {
                return dataContext.Set<Tarefa>().Find(id);
            }
        }
    }
}
