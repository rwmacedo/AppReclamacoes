using System;
using AppReclamacoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AppReclamacoes.Infra.Data.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Reclamacao>
    {
        public void Configure(EntityTypeBuilder<Reclamacao> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(400).IsRequired();

            builder.Property(p => p.Valor).HasPrecision(10, 2);

        }
    }
}

