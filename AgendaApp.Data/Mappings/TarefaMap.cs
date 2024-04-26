using AgendaApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgendaApp.Data.Mappings
{
    /// <summary>
    /// Classe de mapeamento para a entidade Tarefa
    /// </summary>
    public class TarefaMap : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            //nome da tabela do banco de dados
            builder.ToTable("TAREFA");

            //chave primária
            builder.HasKey(t => t.Id);

            //mapeamento dos demais campos
            builder.Property(t => t.Id).HasColumnName("ID");
            builder.Property(t => t.Nome).HasColumnName("NOME").HasMaxLength(100).IsRequired();
            builder.Property(t => t.Descricao).HasColumnName("DESCRICAO").HasMaxLength(100).IsRequired();
            builder.Property(t => t.DataHora).HasColumnName("DATAHORA").IsRequired();
            builder.Property(t => t.Prioridade).HasColumnName("PRIORIDADE").IsRequired();
            builder.Property(t => t.DataHoraCadastro).HasColumnName("DATAHORACADASTRO").IsRequired();
            builder.Property(t => t.DataHoraUltimaAtualizacao).HasColumnName("DATAHORAULTIMAATUALIZACAO").IsRequired();
            builder.Property(t => t.Status).HasColumnName("STATUS").IsRequired();
        }
    }
}
