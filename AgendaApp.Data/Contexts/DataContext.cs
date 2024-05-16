using AgendaApp.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace AgendaApp.Data.Contexts
{
    /// <summary>
    /// Classe de contexto para configuração do EntityFramework
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        /// Método para configurar a connectionstring do banco de dados
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDAgendaApp;Integrated Security=True;");
        }

        /// <summary>
        /// Método para adicionarmos as classes de mapeamento
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
