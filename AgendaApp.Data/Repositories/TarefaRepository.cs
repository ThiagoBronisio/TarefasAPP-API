using AgendaApp.Data.Contexts;
using AgendaApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public List<Tarefa> Get(DateTime? dataInicio, DateTime? dataFim, string? nome)
        {
            using (var dataContext = new DataContext())
            {
                var query = dataContext.Set<Tarefa>().AsQueryable();
                if (nome != null)
                {
                    query = query.Where(t => t.Nome.Contains(nome)).OrderByDescending(t => t.DataHora);
                }
                if (dataInicio != null && dataFim != null)
                {
                    query = query.Where(t => t.DataHora >= dataInicio && t.DataHora <= dataFim).OrderByDescending(t => t.DataHora);
                }
                else if ((nome == null) && (dataInicio == null || dataFim == null))
                {
                    throw new ArgumentException("Ambas as datas de início e fim devem ser preenchidas.");
                }
                return query.ToList();
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
